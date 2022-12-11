using MedicalCenter.Core.Contracts;
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
        private readonly IRepository repository;
        private readonly IDateTimeService dateTimeService;


        public GlobalService(
            UserManager<User> _userManager,
            IRepository _repository,
            IDateTimeService _dateTimeService)
        {
            userManager = _userManager;
            repository = _repository;
            dateTimeService = _dateTimeService;
        }

        public async Task AddUserRoleAsync(User user, string userRole)
        {
            await userManager.AddToRoleAsync(user, userRole);
        }

        public async Task AddClaimAsync(User user)
        {
            await userManager.AddClaimAsync(user, new Claim(ClaimTypeConstants.FirsName, user.FirstName ?? user.Email));
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

        public string ParsePnoneNumber(string phoneNumber)
        {
            return phoneNumber.Contains('+') ? phoneNumber : $"+359{phoneNumber.Remove(0, 1)}";
        }

        public string ReturnDateToString()
        {
            return dateTimeService.GetDate();
        }
    }
}
