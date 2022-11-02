using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(SeedIdentityRoleBase());
        }

        private List<IdentityRole> SeedIdentityRoleBase()
        {
            var roles = new List<IdentityRole>();

            roles.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = RoleConstants.AdministratorRole,
                NormalizedName = RoleConstants.AdministratorRole.ToUpper()
            });
            roles.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = RoleConstants.DoctorRole,
                NormalizedName = RoleConstants.DoctorRole.ToUpper()
            });
            roles.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = RoleConstants.UserRole,
                NormalizedName = RoleConstants.UserRole.ToUpper()
            });

            return roles;
        }
    }
}
