using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Seed Roles

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.AdministratorRole,NormalizedName = RoleConstants.AdministratorRole.ToUpper()},
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.DoctorRole,NormalizedName = RoleConstants.DoctorRole.ToUpper()},
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.UserRole,NormalizedName = RoleConstants.UserRole.ToUpper()}
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // -----------------------------------------------------------------------------

            // Seed Users
            var administratorHasher = new PasswordHasher<User>();
            var administrator = new User
            {
                FirstName = "Ивайло",
                LastName = "Илиев",
                GenderId = 1,
                PhoneNumber = "+359888888888",
                Email = "admin@mc-bg.com",
                NormalizedEmail = "ADMIN@MC-BG.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = administratorHasher.HashPassword(null, "Admin"),
                Role = "Administrator"
            };

            builder.Entity<User>().HasData(administrator);

            var doctorHasher = new PasswordHasher<Doctor>();
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
                    PasswordHash = doctorHasher.HashPassword(null, "Doctor"),
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

            builder.Entity<Doctor>().HasData(doctors);

            builder.Entity<Doctor>()
                .HasOne(e => e.Shedule)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(e => e.Specialty)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            ///----------------------------------------------------

            // Seed UserRoles

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = administrator.Id,
                RoleId = roles.First(q => q.Name == "Administrator").Id
            });

            foreach (var doctor in doctors)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = doctor.Id,
                    RoleId = roles.First(q => q.Name == "Doctor").Id
                });

            }

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
