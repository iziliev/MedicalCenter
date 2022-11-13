using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor);

        Task<DoctorStatisticViewModel> GetDoctorStatisticsAsync(Doctor doctor);
    }
}
