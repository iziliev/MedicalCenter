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

        Task<IEnumerable<DashboardDoctorViewModel>> GetAllCurrentDoctorsAsync();

        Task<IEnumerable<DashboardDoctorViewModel>> GetAllLeftDoctorsAsync();

        Task<Doctor> GetDoctorByEgnAsync(string egn);

        Task AddDoctorRoleAsync(Doctor doctor, string doctorRole);

        Task<IEnumerable<DashboardUserViewModel>> GetAllRegisteredUsersAsync();

        Task<MainDoctorViewModel> GetDoctorByIdToEditAsync(string id);

        Task<Doctor> GetDoctorByIdAsync(string id);

        Task EditDoctorAsync(MainDoctorViewModel doctorModel, Doctor doctor);

        Task DeleteDoctorAsync(string id);

        Task<DashboardStatisticViewModel> GetStatisticsAsync();
    }
}
