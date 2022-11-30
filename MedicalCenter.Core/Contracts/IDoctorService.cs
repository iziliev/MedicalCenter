using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<DashboardDoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor);

        Task<DoctorStatisticViewModel> GetDoctorStatisticsAsync(Doctor doctor);

        Task<Doctor> GetDoctorByIdAsync(string id);

        Task<ShowAllExaminationDoctorViewModel> GetAllDoctorExaminationAsync(
            string doctorId,
            string? searchTerm=null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
