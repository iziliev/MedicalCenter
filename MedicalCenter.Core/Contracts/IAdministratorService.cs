using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    public interface IAdministratorService
    {
        Task<CreateDoctorViewModel> SearchDoctorAsync(string egn);

        Task<IdentityResult> CreateDoctorAsync(CreateDoctorViewModel doctorModel);

        Task ReturnDoctorAsync(string id);

        Task<Doctor> GetDoctorByEgnAsync(string egn);

        Task AddDoctorRoleAsync(Doctor doctor, string doctorRole);

        Task<MainDoctorViewModel> GetDoctorByIdToEditAsync(string id);

        Task EditDoctorAsync(MainDoctorViewModel doctorModel, Doctor doctor);

        Task DeleteDoctorAsync(string id);

        Task<DashboardStatisticDataViewModel> GetStatisticsDataAsync();

        Task<DashboardStatisticViewModel> GetStatisticsAsync();

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
    }
}
