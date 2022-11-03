using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Services
{
    public class GlobalService : IGlobalService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository repository;

        public GlobalService(UserManager<User> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IRepository _repository)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            repository = _repository;
        }

        public async Task CreateRoleAsync()
        {
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.AdministratorRole));
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.DoctorRole));
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.UserRole));
        }

        public async Task AddUsersToRoleAsync()
        {
            var administrator = await userManager.FindByNameAsync("admin");
            var doctors = await repository.All<User>()
                .Where(m => m.Email.EndsWith("@mc-bg.com"))
                .ToListAsync();

            if (administrator != null)
            {
                await userManager.AddToRoleAsync(administrator, RoleConstants.AdministratorRole);
            }

            foreach (var doc in doctors)
            {
                await userManager.AddToRoleAsync(doc, RoleConstants.DoctorRole);
            }
        }

        public async Task AddUserRoleAsync(User user, string userRole)
        {
            await userManager.AddToRoleAsync(user, userRole);
        }

        public async Task AddClaimAsync(User user)
        {
            await userManager
            .AddClaimAsync(user, new Claim(ClaimTypeConstants.FirsName, user.FirstName ?? user.Email));
        }

        public async Task<IEnumerable<Specialty>> GetSpecialtiesAsync()
        {
            return await repository.All<Specialty>().ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await repository.All<Gender>().ToListAsync();
        }

        public async Task<IEnumerable<Shedule>> GetShedulesAsync()
        {
            return await repository.All<Shedule>().ToListAsync();
        }

        public async Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel)
        {
            doctorEditModel.Genders = await GetGendersAsync();
            doctorEditModel.Specialties = await GetSpecialtiesAsync();
            doctorEditModel.Shedules = await GetShedulesAsync();

            return doctorEditModel;
        }

        public async Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel)
        {
            doctorCreateModel.Genders = await GetGendersAsync();
            doctorCreateModel.Specialties = await GetSpecialtiesAsync();
            doctorCreateModel.Shedules = await GetShedulesAsync();

            return doctorCreateModel;
        }
    }
}
