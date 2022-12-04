using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// All laborant view model
    /// </summary>
    public class ShowAllLaborantViewModel
    {
        /// <summary>
        /// Laborant per page
        /// </summary>
        public const int LaborantPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        /// <summary>
        /// Laborants count
        /// </summary>
        public int TotalLaborantsCount { get; set; }

        /// <summary>
        /// Search term egn
        /// </summary>
        public string? SearchTermEgn { get; set; }

        /// <summary>
        /// Search term name
        /// </summary>
        public string? SearchTermName { get; set; }

        /// <summary>
        /// Collection laborants
        /// </summary>
        public IEnumerable<DashboardLaborantViewModel> Laborants { get; set; } = new List<DashboardLaborantViewModel>();
    }
}
