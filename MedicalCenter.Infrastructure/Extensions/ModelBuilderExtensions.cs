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
            var userAdmin = FillUserAdministratorData();
            builder.Entity<User>().HasData(userAdmin);
            var administrator = FillAdministratorData();
            builder.Entity<Administrator>().HasData(administrator);

            //Seed Doctors

            var usersDoctor = FillUserDoctorData();
            builder.Entity<User>().HasData(usersDoctor);
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

            var userLaborant = FillLaborantUserData();
            builder.Entity<User>().HasData(userLaborant);
            var laborant = FillLaborantData();
            builder.Entity<Laborant>().HasData(laborant);
                       
            builder.Entity<User>()
                .HasOne<Laborant>(e => e.Laborant)
                .WithOne(s => s.User)
                .HasForeignKey<Laborant>(s => s.UserId);

            // Seed UserRoles(Administrator and Doctors)

            var userRoles = FillUsersRole(userAdmin, roles, usersDoctor, userLaborant);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }

        private static List<IdentityUserRole<string>> FillUsersRole(User user, List<IdentityRole> roles, List<User> doctors, User laborant)
        {
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
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

        private static User FillUserAdministratorData()
        {
            var administratorHasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = GuidIdsConstants.AdministratorUserGuidConstants,
                FirstName = "Ивайло",
                LastName = "Илиев",
                GenderId = 1,
                PhoneNumber = "+359888888888",
                Email = "admin@mc-bg.com",
                NormalizedEmail = "ADMIN@MC-BG.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Role = "Administrator",
                JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                AdministratorId = GuidIdsConstants.AdministratorGuidConstants
            };

            user.PasswordHash = administratorHasher.HashPassword(user, "Admin");
            return user;
        }

        private static Administrator FillAdministratorData()
        {
            return new Administrator
            {
                Id = GuidIdsConstants.AdministratorGuidConstants,
                UserId = GuidIdsConstants.AdministratorUserGuidConstants,
                Egn = "9305264209"
            };
        }

        private static List<User> FillUserDoctorData()
        {
            var users = new List<User>();

            var doctorHasher = new PasswordHasher<User>();
            var doctorsData = DoctorConstants.DoctorsData
                .Split(" ")
                .ToArray();

            var doctorsGuid = GuidIdsConstants.DoctorUserGuidConstants
                .Split(",")
                .ToArray();

            var doctorsDoctorGuid = GuidIdsConstants.DoctorGuidConstants
                .Split(",")
                .ToArray();

            var doctorCount = 1;
            var lastTel = 100;
            var guidCount = 0;

            for (int i = 0; i < doctorsData.Length; i += 6)
            {
                var lastName = doctorsData[i + 1];
                var genderByName = lastName[^1].Equals('а') ? 2 : 1;

                var user = new User
                {
                    Id = doctorsGuid[guidCount],
                    FirstName = doctorsData[i],
                    LastName = lastName,
                    UserName = doctorsData[i + 3],
                    NormalizedUserName = doctorsData[i + 3].ToUpper(),
                    Email = string.Concat(doctorsData[i + 3], "@mc-bg.com"),
                    NormalizedEmail = string.Concat(doctorsData[i + 3], "@mc-bg.com").ToUpper(),
                    PhoneNumber = $"+359888888{lastTel++}",
                    GenderId = genderByName,
                    Role = "Doctor",
                    JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    DoctorId = doctorsDoctorGuid[guidCount]
                };

                user.PasswordHash = doctorHasher.HashPassword(user, "Doctor");
                users.Add(user);
                doctorCount++;
                guidCount++;
            }
            return users;
        }

        private static List<Doctor> FillDoctorData()
        {
            var doctors = new List<Doctor>();

            var doctorsData = DoctorConstants.DoctorsData
                .Split(" ")
                .ToArray();

            var doctorsGuid = GuidIdsConstants.DoctorGuidConstants
                .Split(",")
                .ToArray();

            var doctorsUserGuid = GuidIdsConstants.DoctorUserGuidConstants
                .Split(",")
                .ToArray();

            var doctorCount = 1;
            var guidCount = 0;

            for (int i = 0; i < doctorsData.Length; i += 6)
            {
                var d = new Doctor
                {
                    Id = doctorsGuid[guidCount],
                    ProfileImageUrl = doctorsData[i + 2],
                    Biography = DoctorConstants.Biography,
                    Education = DoctorConstants.Education,
                    SpecialtyId = int.Parse(doctorsData[i + 5]),
                    Representation = DoctorConstants.Representation,
                    Egn = doctorsData[i + 4],
                    SheduleId = doctorCount % 2 == 0 ? 2 : 1,
                    UserId = doctorsUserGuid[guidCount]
                };
                doctors.Add(d);
                guidCount++;
            }
            return doctors;
        }

        private static User FillLaborantUserData()
        {
            var laborantHasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = GuidIdsConstants.LaborantUserGuidConstants,
                FirstName = "Ваня",
                LastName = "Иванова",
                GenderId = 2,
                PhoneNumber = "+359888888881",
                Email = "lab_vivanova@mc-bg.com",
                NormalizedEmail = "LAB_VIVANOVA@MC-BG.COM",
                UserName = "lab_vivanova",
                NormalizedUserName = "LAB_VIVANOVA",
                Role = "Laborant",
                JoinOnDate = DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                LaborantId = GuidIdsConstants.LaborantGuidConstants,
            };
            user.PasswordHash = laborantHasher.HashPassword(user, "Laborant");
            return user;
        }

        private static Laborant FillLaborantData()
        {
            var laborant = new Laborant
            {
                Id = GuidIdsConstants.LaborantGuidConstants,
                Egn = "8412194792",
                UserId= GuidIdsConstants.LaborantUserGuidConstants,
            };
            return laborant;
        }
    }
}
