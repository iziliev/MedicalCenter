using MedicalCenter.Infrastructure.Data.Global;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// All userview model
    /// </summary>
    public class ShowAllUserViewModel
    {
        /// <summary>
        /// User per page
        /// </summary>
        public const int UsersPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        /// <summary>
        /// Users count
        /// </summary>
        public int TotalUsersCount { get; set; }

        /// <summary>
        /// Search term email
        /// </summary>
        public string? SearchTermEmail { get; set; }

        /// <summary>
        /// Search term name
        /// </summary>
        public string? SearchTermName { get; set; }

        /// <summary>
        /// Collection users
        /// </summary>
        public IEnumerable<DashboardUserViewModel> AllUsers { get; set; } = new List<DashboardUserViewModel>();
    }
}
