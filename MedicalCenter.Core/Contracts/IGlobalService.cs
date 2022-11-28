using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IGlobalService
    {
        string ParsePnoneNumber(string phoneNumber);

        Task AddUserRoleAsync(User user, string userRole);

        Task AddClaimAsync(User user);

        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        Task<IEnumerable<Shedule>> GetShedulesAsync();

        Task<IEnumerable<Gender>> GetGendersAsync();

    }
}