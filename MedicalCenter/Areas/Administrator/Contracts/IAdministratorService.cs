using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Areas.Contracts
{
    public interface IAdministratorService
    {
        /// <summary>
        /// Return Laborant, Doctor or Administrator
        /// </summary>
        /// <typeparam name="T">is CreateLaborantViewModel,CreateDoctorViewModel or CreateAdminViewModel</typeparam>
        /// <typeparam name="Z">is Laborant,Doctor or Administrator</typeparam>
        /// <param name="egn">record EGN</param>
        /// <returns>Single record</returns>
        Task<T> SearchUserByEgnAsync<T, Z>(string egn) 
            where T : class 
            where Z : class;

        /// <summary>
        /// Return IdentityResult to succseed or nor create relevant user
        /// </summary>
        /// <typeparam name="T">CreateLaborantViewModel,CreateDoctorViewModel or CreateAdminViewModel</typeparam>
        /// <param name="userModel">Given model to record</param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> CreateUserAsync<T>(T userModel)
            where T : class;

        /// <summary>
        /// Resumes relevant user to the system
        /// </summary>
        /// <typeparam name="T">Is class Doctor,Laborant or Administrator</typeparam>
        /// <param name="id">record identificator</param>
        Task ReturnAsync<T>(string id)
            where T : class;

        /// <summary>
        /// Search the relevant user in database
        /// </summary>
        /// <typeparam name="T">Is class Doctor,Laborant or Administrator</typeparam>
        /// <param name="egn">record Egn</param>
        /// <returns>Single record</returns>
        Task<T> GetByEgnAsync<T>(string egn) 
            where T : class;

        /// <summary>
        /// Get relevant user by identificator
        /// </summary>
        /// <typeparam name="T">Is class Doctor,Laborant or Administrator</typeparam>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T> GetUserByIdAsync<T>(string id) 
            where T : class;
        
        /// <summary>
        /// Add relevant user to role
        /// </summary>
        /// <param name="user">created user</param>
        /// <param name="roleName">record role</param>
        Task AddRoleAsync(User user, string roleName);

        /// <summary>
        /// Get relevant user by identificator
        /// </summary>
        /// <typeparam name="T">MainDoctorViewModel,MainLaborantViewModel or MainAdminViewModel</typeparam>
        /// <typeparam name="Z">Doctor,Laborant or Administrator</typeparam>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T> GetUserByIdToEditAsync<T,Z>(string id)
            where T : class
            where Z : class;

        /// <summary>
        /// Show relevant user to Edit
        /// </summary>
        /// <typeparam name="T">MainDoctorViewModel,MainLaborantViewModel or MainAdminViewModel</typeparam>
        /// <typeparam name="Z">Doctor,Laborant or Administrator</typeparam>
        /// <param name="userModel">record relevant user to MainDoctorViewModel,MainLaborantViewModel or MainAdminViewModel</param>
        /// <param name="user">record relevant user</param>
        Task EditUserAsync<T, Z>(T userModel, Z user) 
            where T : class
            where Z : class;

        /// <summary>
        /// Delete relevant user
        /// </summary>
        /// <typeparam name="T">Doctor,Laborant or Administrator</typeparam>
        /// <param name="id">record identificator</param>
        Task DeleteAsync<T>(string id)
            where T : class;

        /// <summary>
        /// Show statistic by relevant user
        /// </summary>
        /// <typeparam name="T">DashboardStatisticDataViewModel,DashboardStatisticLabViewModel,DashboardStatisticViewModel or DashboardStatisticAdminViewModel</typeparam>
        /// <returns>Single record</returns>
        Task<T> GetStatisticsAsync<T>()
            where T : class;

        /// <summary>
        /// Get all recorded specialities
        /// </summary>
        /// <returns>Collection specialities</returns>
        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        /// <summary>
        /// Get recorded shedule
        /// </summary>
        /// <returns>Collection of shedules</returns>
        Task<IEnumerable<Shedule>> GetShedulesAsync();

        /// <summary>
        /// Get record genders
        /// </summary>
        /// <returns>Collection of genders</returns>
        Task<IEnumerable<Gender>> GetGendersAsync();

        /// <summary>
        /// To logout relevant user
        /// </summary>
        Task Logout();

        /// <summary>
        /// To fill all collections from database in Edit model
        /// </summary>
        /// <param name="doctorEditModel">MainDoctorViewModel</param>
        /// <returns>same model</returns>
        Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel);

        /// <summary>
        /// To fill all collections from database in Create model
        /// </summary>
        /// <param name="doctorCreateModel">CreateDoctorViewModel</param>
        /// <returns>same model</returns>
        Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel);

        /// <summary>
        /// Show all past examination
        /// </summary>
        /// <param name="speciality">record speciality</param>
        /// <param name="searchTermDate">choose date</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="examinationPerPage">show examination per page</param>
        /// <returns>record all past examination</returns>
        Task<ShowAllExaminationViewModel> GetAllPastExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all examination in future
        /// </summary>
        /// <param name="speciality">record specialities</param>
        /// <param name="searchTermDate">choose date</param>
        /// <param name="searchTermName">write nameparam>
        /// <param name="currentPage">current page</param>
        /// <param name="examinationPerPage">show examination per page</param>
        /// <returns>record all examination in future</returns>
        Task<ShowAllExaminationViewModel> GetAllFutureExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all Administrators without administrator which make query and make CRUD operations
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <param name="searchTermEgn">write Egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="adminsPerPage">show administrators per page</param>
        /// <returns>recordered administrators</returns>
        Task<ShowAllAdminViewModel> GetAllCurrentAdminAsync(
            string id,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all doctors and makes CRUD operations
        /// </summary>
        /// <param name="speciality">record specialities</param>
        /// <param name="searchTermEgn">write egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="doctorsPerPage">show doctor per page</param>
        /// <returns>recordered of doctors</returns>
        Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all laborants and makes CRUD operations
        /// </summary>
        /// <param name="searchTermEgn">write egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="laborantsPerPage">show laborant per page</param>
        /// <returns>recordered laborants</returns>
        Task<ShowAllLaborantViewModel> GetAllCurrentLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all registered Users
        /// </summary>
        /// <param name="searchTermEmail">write email</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="doctorsPerPage">show registered user per page</param>
        /// <returns>recordered users</returns>
        Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(
            string? searchTermEmail = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all left doctors and makes CRUD operations
        /// </summary>
        /// <param name="speciality">record specialities</param>
        /// <param name="searchTermEgn">write egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="doctorsPerPage">show doctor per page</param>
        /// <returns>recordered left doctors</returns>
        Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all left laborants and makes CRUD operations
        /// </summary>
        /// <param name="searchTermEgn">write egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="laborantsPerPage">show laborant per page</param>
        /// <returns>recordered left laborants</returns>
        Task<ShowAllLaborantViewModel> GetAllLeftLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantssPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Show all left administrators which make query and make CRUD operations
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <param name="searchTermEgn">write Egn</param>
        /// <param name="searchTermName">write name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="adminsPerPage">show administrators per page</param>
        /// <returns>recordered left administrators</returns>
        Task<ShowAllAdminViewModel> GetAllLeftAdminAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
