using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// All examination view model
    /// </summary>
    public class ShowAllExaminationViewModel
    {
        /// <summary>
        /// Examination per page
        /// </summary>
        public const int ExaminationPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        /// <summary>
        /// Total examination
        /// </summary>
        public int TotalExaminationCount { get; set; }

        /// <summary>
        /// Search term name
        /// </summary>
        public string? SearchTermName { get; set; }

        /// <summary>
        /// Speciality
        /// </summary>
        public string? Speciality { get; set; }

        /// <summary>
        /// Search term date
        /// </summary>
        public string? SearchTermDate { get; set; }

        /// <summary>
        /// Collection specialities
        /// </summary>
        public IEnumerable<Specialty> Specialities { get; set; } = new List<Specialty>();

        /// <summary>
        /// Collection of examination
        /// </summary>
        public IEnumerable<DashboardExaminationViewModel> AllExamination { get; set; } = new List<DashboardExaminationViewModel>();
    }
}
