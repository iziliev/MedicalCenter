using MedicalCenter.Core.Models.Administrator;
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

        Task<DashboardStatisticViewModel> GetStatisticsAsync();

        Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(int currentPage = 1, int doctorsPerPage = 6);

        Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(int currentPage = 1, int doctorsPerPage = 6);

        Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(int currentPage = 1, int doctorsPerPage = 6);
    }
}
