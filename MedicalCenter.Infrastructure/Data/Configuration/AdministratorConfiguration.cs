using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class AdministratorConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedAdministratorBase());
        }

        private User SeedAdministratorBase()
        {
            var hasher = new PasswordHasher<User>();
            return new User
            {
                FirstName = "Ивайло",
                LastName = "Илиев",
                GenderId = 1,
                PhoneNumber = "+359888888888",
                Email = "admin@mc-bg.com",
                NormalizedEmail = "ADMIN@MC-BG.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "Admin"),
                Role = "Administrator"
            };
        }
    }


}
