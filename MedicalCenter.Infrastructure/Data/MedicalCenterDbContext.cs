using MedicalCenter.Infrastructure.Data.Configuration;
using MedicalCenter.Infrastructure.Data.Models;
using MedicalCenter.Infrastructure.Extensions;
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

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Laborant> Laborants { get; set; }

        public DbSet<LaboratoryPatient> LaboratoryPatients { get; set; }

        public DbSet<Test> Tests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExaminationConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new SpecialityConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new SheduleConfiguration());
            builder.ApplyConfiguration(new WorkHourConfiguration());

            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}