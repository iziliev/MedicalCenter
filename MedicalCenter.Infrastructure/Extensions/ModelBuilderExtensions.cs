using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Extensions
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
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.UserRole,NormalizedName = RoleConstants.UserRole.ToUpper()},
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.LaborantRole,NormalizedName = RoleConstants.LaborantRole.ToUpper()},
                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = RoleConstants.LaboratoryUserRole,NormalizedName = RoleConstants.LaboratoryUserRole.ToUpper()},
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Administrator
            var administrator = FillAdministratorData();
            builder.Entity<User>().HasData(administrator);

            //Seed Doctors
            var doctors = FillDoctorData();
            builder.Entity<Doctor>().HasData(doctors);

            builder.Entity<Doctor>()
                .HasOne(e => e.Shedule)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(e => e.Specialty)
                .WithMany(e => e.Doctors)
                .OnDelete(DeleteBehavior.Restrict);

            //Seed Laborants

            var laborant = FillLaborantData();
            builder.Entity<Laborant>().HasData(laborant);

            // Seed UserRoles(Administrator and Doctors)
            var userRoles = FillUsersRole(administrator, roles, doctors, laborant);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }

        private static List<IdentityUserRole<string>> FillUsersRole(User administrator, List<IdentityRole> roles, List<Doctor> doctors, Laborant laborant)
        {
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

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = laborant.Id,
                RoleId = roles.First(q => q.Name == "Laborant").Id
            });

            return userRoles;
        }

        private static User FillAdministratorData()
        {
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
                Role = "Administrator"
            };
            administrator.PasswordHash = administratorHasher.HashPassword(administrator, "Admin");
            return administrator;
        }

        private static List<Doctor> FillDoctorData()
        {
            var doctors = new List<Doctor>();

            var doctorHasher = new PasswordHasher<Doctor>();
            var doctorsData = DoctorConstants.DoctorsData
                .Split(" ")
                .ToArray();

            var doctorCount = 1;
            var lastTel = 100;

            for (int i = 0; i < doctorsData.Length; i += 6)
            {
                var lastName = doctorsData[i + 1];
                var genderByName = lastName[^1].Equals('а') ? 2 : 1;

                var d = new Doctor
                {
                    FirstName = doctorsData[i],
                    LastName = lastName,
                    ProfileImageUrl = doctorsData[i + 2],
                    UserName = doctorsData[i + 3],
                    NormalizedUserName = doctorsData[i + 3].ToUpper(),
                    Biography = DoctorConstants.Biography,
                    Education = DoctorConstants.Education,
                    Email = string.Concat(doctorsData[i + 3], "@mc-bg.com"),
                    NormalizedEmail = string.Concat(doctorsData[i + 3], "@mc-bg.com").ToUpper(),
                    PhoneNumber = $"+359888888{lastTel++}",
                    SpecialtyId = int.Parse(doctorsData[i + 5]),
                    Representation = DoctorConstants.Representation,
                    GenderId = genderByName,
                    Egn = doctorsData[i + 4],
                    Role = "Doctor",
                    JoinOnDate = DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    SheduleId = doctorCount % 2 == 0 ? 2 : 1,
                };
                d.PasswordHash = doctorHasher.HashPassword(d, "Doctor");
                doctors.Add(d);
                doctorCount++;
            }
            return doctors;
        }

        private static Laborant FillLaborantData()
        {
            var laborantHasher = new PasswordHasher<Laborant>();
            var laborant = new Laborant
            {
                FirstName = "Ваня",
                LastName = "Иванова",
                GenderId = 2,
                Egn = "8412194792",
                PhoneNumber = "+359888888881",
                Email = "lab_vivanova@mc-bg.com",
                NormalizedEmail = "LAB_VIVANOVA@MC-BG.COM",
                UserName = "lab_vivanova",
                NormalizedUserName = "LAB_VIVANOVA",
                Role = "Laborant",
                JoinOnDate = DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
            };
            laborant.PasswordHash = laborantHasher.HashPassword(laborant, "Laborant");
            return laborant;
        }
    }
}
