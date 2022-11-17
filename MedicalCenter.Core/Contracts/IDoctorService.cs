using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<DashboardDoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor);

        Task<DoctorStatisticViewModel> GetDoctorStatisticsAsync(Doctor doctor);

        Task<ShowAllExaminationDoctorViewModel> GetAllDoctorExaminationAsync(string doctorId,string? searchTerm=null, int currentPage = 1, int examinationPerPage = 6);
    }
}
