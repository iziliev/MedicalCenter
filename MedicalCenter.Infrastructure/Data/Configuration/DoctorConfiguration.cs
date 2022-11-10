using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasOne(e => e.Shedule)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Specialty)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedDoctorBase());
        }

        private List<Doctor> SeedDoctorBase()
        {
            var hasher = new PasswordHasher<Doctor>();
            var doctorsData = DoctorConstants.DoctorsData
                .Split(" ")
                .ToArray();

            var doctors = new List<Doctor>();
            var doctorCount = 1;
            var lastTel = 100;

            for (int i = 0; i < doctorsData.Length; i += 6)
            {
                var lastName = doctorsData[i + 1];
                var genderByName = lastName[lastName.Length - 1].Equals('а') ? 2 : 1;

                var d = new Doctor
                {
                    FirstName = doctorsData[i],
                    LastName = lastName,
                    ProfileImageUrl = doctorsData[i + 2],
                    UserName = doctorsData[i + 3],
                    NormalizedUserName = doctorsData[i + 3].ToUpper(),
                    Biography = DoctorConstants.Biography,
                    Education = DoctorConstants.Education,
                    Email = String.Concat(doctorsData[i + 3], "@mc-bg.com"),
                    NormalizedEmail = String.Concat(doctorsData[i + 3], "@mc-bg.com").ToUpper(),
                    PhoneNumber = $"+359888888{lastTel++}",
                    SpecialtyId = int.Parse(doctorsData[i + 5]),
                    PasswordHash = hasher.HashPassword(null, "Doctor"),
                    Representation = DoctorConstants.Representation,
                    GenderId = genderByName,
                    Egn = doctorsData[i + 4],
                    Role = "Doctor",
                    JoinOnDate = DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    SheduleId = doctorCount % 2 == 0 ? 2 : 1,
                };
                doctorCount++;
                doctors.Add(d);
            }
            return doctors;
        }

    }
}
