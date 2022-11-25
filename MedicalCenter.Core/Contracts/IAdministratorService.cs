using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    public interface IAdministratorService
    {
        Task<CreateDoctorViewModel> SearchDoctorByEgnAsync(string egn);

        Task<CreateLaborantViewModel> SearchLaborantByEgnAsync(string egn);

        Task<IdentityResult> CreateDoctorAsync(CreateDoctorViewModel doctorModel);

        Task<IdentityResult> CreateLaborantAsync(CreateLaborantViewModel laborantModel);

        Task ReturnDoctorAsync(string id);

        Task ReturnLaborantAsync(string id);

        Task<Doctor> GetDoctorByEgnAsync(string egn);

        Task<Laborant> GetLaborantByEgnAsync(string egn);

        Task AddDoctorRoleAsync(Doctor doctor, string doctorRole);

        Task AddLaborantRoleAsync(Laborant laborant, string laborantRole);

        Task<MainDoctorViewModel> GetDoctorByIdToEditAsync(string id);

        Task EditDoctorAsync(MainDoctorViewModel doctorModel, Doctor doctor);

        Task<MainLaborantViewModel> GetLaborantByIdToEditAsync(string id);

        Task EditLaborantAsync(MainLaborantViewModel laborantModel, Laborant laborant);

        Task DeleteDoctorAsync(string id);

        Task DeleteLaborantAsync(string id);

        Task<DashboardStatisticDataViewModel> GetStatisticsDataAsync();

        Task<DashboardStatisticViewModel> GetStatisticsAsync();

        Task<DashboardStatisticLabViewModel> GetStatisticsLabAsync();

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
    }
}
