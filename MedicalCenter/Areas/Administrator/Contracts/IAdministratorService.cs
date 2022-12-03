using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Areas.Contracts
{
    public interface IAdministratorService
    {
        Task<T> SearchUserByEgnAsync<T, Z>(string egn) 
            where T : class 
            where Z : class;

        Task<IdentityResult> CreateUserAsync<T>(T userModel)
            where T : class;

        Task ReturnAsync<T>(string id)
            where T : class;

        Task<T> GetByEgnAsync<T>(string egn) 
            where T : class;

        Task<Infrastructure.Data.Models.Administrator> GetAdminByUserIdAsync(string id);

        Task<T> GetUserByIdAsync<T>(string id) 
            where T : class;
        
        Task AddRoleAsync(User user, string roleName);

        Task<T> GetUserByIdToEditAsync<T,Z>(string id)
            where T : class
            where Z : class;

        Task EditUserAsync<T, Z>(T userModel, Z user) 
            where T : class
            where Z : class;

        Task DeleteAsync<T>(string id)
            where T : class;

        Task<T> GetStatisticsAsync<T>()
            where T : class;

        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        Task<IEnumerable<Shedule>> GetShedulesAsync();

        Task<IEnumerable<Gender>> GetGendersAsync();

        Task Logout();

        Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel);

        Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel);

        Task<ShowAllExaminationViewModel> GetAllPastExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllExaminationViewModel> GetAllFutureExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllAdminViewModel> GetAllCurrentAdminAsync(
            string id,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllLaborantViewModel> GetAllCurrentLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(
            string? searchTermEmail = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllLaborantViewModel> GetAllLeftLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantssPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllAdminViewModel> GetAllLeftAdminAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
