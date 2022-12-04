using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    /// <summary>
    /// Doctors manipulation
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// All examination on doctor
        /// </summary>
        /// <param name="doctor">record Doctor</param>
        /// <returns>collection DashboardDoctorExaminationViewModel</returns>
        Task<IEnumerable<DashboardDoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor);

        /// <summary>
        /// Doctor statistic
        /// </summary>
        /// <param name="doctor">record Doctor</param>
        /// <returns>DoctorStatisticViewModel</returns>
        Task<DoctorStatisticViewModel> GetDoctorStatisticsAsync(Doctor doctor);

        /// <summary>
        /// Get doctor by identificator
        /// </summary>
        /// <param name="id">record identificator</param>
        /// <returns>recorded doctor</returns>
        Task<Doctor> GetDoctorByIdAsync(string id);

        /// <summary>
        /// All doctor examination
        /// </summary>
        /// <param name="doctorId">doctor identificator</param>
        /// <param name="searchTerm">search term</param>
        /// <param name="currentPage">current page</param>
        /// <param name="examinationPerPage">exam per page</param>
        /// <returns></returns>
        Task<ShowAllExaminationDoctorViewModel> GetAllDoctorExaminationAsync(
            string doctorId,
            string? searchTerm=null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
