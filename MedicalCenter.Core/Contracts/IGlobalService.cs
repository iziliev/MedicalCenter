using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IGlobalService
    {
        /// <summary>
        /// Parse phone number
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        /// <returns>phone number in string</returns>
        string ParsePnoneNumber(string phoneNumber);

        /// <summary>
        /// User to role
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="userRole">role</param>
        Task AddUserRoleAsync(User user, string userRole);

        /// <summary>
        /// add claim to user
        /// </summary>
        /// <param name="user">user</param>
        Task AddClaimAsync(User user);

        /// <summary>
        /// Show specialities
        /// </summary>
        /// <returns>Collection on specialities</returns>
        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        /// <summary>
        /// Show shedule
        /// </summary>
        /// <returns>Collection on shedule</returns>
        Task<IEnumerable<Shedule>> GetShedulesAsync();

        /// <summary>
        /// Show genders
        /// </summary>
        /// <returns>Collection on gender</returns>
        Task<IEnumerable<Gender>> GetGendersAsync();

        string ReturnDateToString();

    }
}