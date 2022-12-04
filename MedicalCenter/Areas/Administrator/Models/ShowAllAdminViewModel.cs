using MedicalCenter.Infrastructure.Data.Global;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// All admin view model
    /// </summary>
    public class ShowAllAdminViewModel
    {
        /// <summary>
        /// Admin per page
        /// </summary>
        public const int AdminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        /// <summary>
        /// admins count
        /// </summary>
        public int TotalAdminsCount { get; set; }

        /// <summary>
        /// Search term Egn
        /// </summary>
        public string? SearchTermEgn { get; set; }

        /// <summary>
        /// Search term name
        /// </summary>
        public string? SearchTermName { get; set; }

        /// <summary>
        /// Collection Admins
        /// </summary>
        public IEnumerable<DashboardAdminViewModel> Admins { get; set; } = new List<DashboardAdminViewModel>();
    }
}
