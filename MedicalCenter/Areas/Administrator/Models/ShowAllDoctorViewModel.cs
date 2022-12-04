using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// All doctor view model
    /// </summary>
    public class ShowAllDoctorViewModel
    {
        /// <summary>
        /// Doctor per page
        /// </summary>
        public const int DoctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        /// <summary>
        /// Doctors count
        /// </summary>
        public int TotalDoctorsCount { get; set; }

        /// <summary>
        /// Search term egn
        /// </summary>
        public string? SearchTermEgn { get; set; }

        /// <summary>
        /// Search term name
        /// </summary>
        public string? SearchTermName { get; set; }

        /// <summary>
        /// Speciality
        /// </summary>
        public string? Specialty { get; set; }

        /// <summary>
        /// Collection of specialities
        /// </summary>
        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        /// <summary>
        /// Collection of doctors
        /// </summary>
        public IEnumerable<DashboardDoctorViewModel> Doctors { get; set; } = new List<DashboardDoctorViewModel>();
    }
}
