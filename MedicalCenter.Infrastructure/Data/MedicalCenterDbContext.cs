using MedicalCenter.Extensions;
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
            builder.ApplyConfiguration(new ExaminationConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new SpecialityConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            //builder.ApplyConfiguration(new AdministratorConfiguration());
            //builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new SheduleConfiguration());
            builder.ApplyConfiguration(new WorkHourConfiguration());
            //builder.ApplyConfiguration(new IdentityRoleConfiguration());

            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}