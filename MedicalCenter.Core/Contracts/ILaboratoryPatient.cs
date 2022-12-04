using MedicalCenter.Core.Models.LaboratoryPatient;
using MedicalCenter.Infrastructure.Data.Global;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    /// <summary>
    /// Laboratory patient manipulation
    /// </summary>
    public interface ILaboratoryPatient
    {
        /// <summary>
        /// Login laboratory patient
        /// </summary>
        /// <param name="loginModel">LoginPatientViewModel</param>
        /// <returns>SignInResult</returns>
        Task<SignInResult> Login(LoginPatientViewModel loginModel);

        /// <summary>
        /// Egn exist
        /// </summary>
        /// <param name="egn">record egn</param>
        /// <returns>true or false</returns>
        Task<bool> IsEgnExistAsync(string egn);

        /// <summary>
        /// username exist
        /// </summary>
        /// <param name="username">record username</param>
        /// <returns>true or false</returns>
        Task<bool> IsUsernameExistAsync(string username);

        /// <summary>
        /// all laboratory patient tests
        /// </summary>
        /// <param name="userId">record identificator/param>
        /// <param name="searchTermDate">date choose</param>
        /// <param name="currentPage">current page</param>
        /// <param name="laboratoryPatientPerPage">test per page</param>
        /// <returns>ShowAllLaboratoryPatientResultViewModel</returns>
        Task<ShowAllLaboratoryPatientResultViewModel> GetAllResult(
            string userId,
            string? searchTermDate = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// All result
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>ResultViewModel</returns>
        Task<ResultViewModel> GetResultByIdAsync(string id);
    }
}
