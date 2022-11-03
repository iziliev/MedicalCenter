using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorAsync(string id);

        Task<IEnumerable<DoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor);

        DoctorStatisticViewModel DoctorStatistic(Doctor doctor);
    }
}
