using MedicalCenter.Infrastructure.Data.Configuration;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Infrastructure.Data
{
    public class MedicalCenterDbContext : IdentityDbContext<User>
    {
        public MedicalCenterDbContext(DbContextOptions<MedicalCenterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Examination> Examinations { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Specialty> Specialties { get; set; } = null!;

        public DbSet<Gender> Genders { get; set; } = null!;

        public DbSet<Shedule> Shedules { get; set; } = null!;

        public DbSet<WorkHour> WorkHours { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Examination>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserExaminations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Examination>()
                .HasOne(e => e.Doctor)
                .WithMany(e => e.DoctorExaminations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkHour>()
                .HasOne(e => e.Shedule)
                .WithMany(e => e.WorkHours)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(e => e.Shedule)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(e => e.Specialty)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserReviews)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(u => u.Doctor)
                .WithMany(u => u.DoctorReviews)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new SpecialityConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new AdministratorConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new SheduleConfiguration());
            builder.ApplyConfiguration(new WorkHourConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}