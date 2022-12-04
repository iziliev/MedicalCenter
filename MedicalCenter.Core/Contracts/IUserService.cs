using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> Register(RegisterViewModel registerModel);

        /// <summary>
        /// Check username exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        Task<bool> IsUsernameExistAsync(string username);

        /// <summary>
        /// Check Email exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        Task<bool> IsUserEmailExistAsync(string username);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>SignInResult</returns>
        Task<SignInResult> Login(LoginViewModel loginModel);

        /// <summary>
        /// Logout
        /// </summary>
        Task Logout();

        /// <summary>
        /// Take user by username
        /// </summary>
        /// <param name="username">record username</param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Doctor working time
        /// </summary>
        /// <param name="doctorId">record identificator</param>
        /// <returns>collection work hour</returns>
        Task<IEnumerable<string>> GetDoctorWorkHoursByDoctorIdAsync (string doctorId);

        /// <summary>
        /// Doctor by Id
        /// </summary>
        /// <param name="doctorId">record identificator</param>
        /// <returns>Doctor</returns>
        Task<Doctor> GetDoctorByIdAsync(string doctorId);

        /// <summary>
        /// Create examination
        /// </summary>
        /// <param name="user">record user</param>
        /// <param name="doctor">record doctor</param>
        /// <param name="bookModel">book model</param>
        Task CreateExaminationAsync(User user,Doctor doctor, BookExaminationViewModel bookModel);

        /// <summary>
        /// Check user not have any other book examination
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="bookModel"></param>
        /// <returns>bool</returns>
        Task<bool> IsUserFreeOnDateAnHourAsync(string userId, BookExaminationViewModel bookModel);

        /// <summary>
        /// Check doctor not have any other book examination
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="bookModel"></param>
        /// <returns>bool</returns>
        Task<bool> IsDoctorFreeOnDateAnHourAsync(BookExaminationViewModel bookModel);

        Task<string> ReturnDoctorNameByDoctorIdAsync(string doctorId);

        Task CancelUserExaminationAsync(string examinationId);

        /// <summary>
        /// Fill book model
        /// </summary>
        /// <param name="doctorId">record identificator</param>
        /// <returns>BookExaminationViewModel</returns>
        Task<BookExaminationViewModel> FillBookViewModelAsync(string doctorId);

        /// <summary>
        /// Show examinations
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="bookModel"></param>
        /// <returns>examination</returns>
        Task<Examination> GetExaminationAsync(string userId, BookExaminationViewModel bookModel);

        /// <summary>
        /// Show doctors
        /// </summary>
        /// <param name="speciality"></param>
        /// <param name="searchTerm"></param>
        /// <param name="currentPage"></param>
        /// <param name="doctorsPerPage"></param>
        /// <returns>ShowAllDoctorUserViewModel</returns>
        Task<ShowAllDoctorUserViewModel> ShowDoctorOnUserAsync(
            string? speciality = null, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show examination
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="speciality"></param>
        /// <param name="searchTermDate"></param>
        /// <param name="searchTermName"></param>
        /// <param name="currentPage"></param>
        /// <param name="examinationsPerPage"></param>
        /// <returns>ShowAllUserExaminationViewModel</returns>
        Task<ShowAllUserExaminationViewModel> GetAllCurrentExaminationAsync(
            string userId,
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show examination for feedback
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="speciality"></param>
        /// <param name="searchTermDate"></param>
        /// <param name="searchTermName"></param>
        /// <param name="currentPage"></param>
        /// <param name="reviewPerPage"></param>
        /// <returns>ShowAllExaminationForReviewViewModel</returns>
        Task<ShowAllExaminationForReviewViewModel> GetAllExaminationForReviewAsync(
            string userId, 
            string? speciality = null,
            string? searchTermDate = null,
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}