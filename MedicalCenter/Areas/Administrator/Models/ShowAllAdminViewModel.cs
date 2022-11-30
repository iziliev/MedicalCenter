using MedicalCenter.Infrastructure.Data.Global;

namespace MedicalCenter.Areas.Administrator.Models
{
    public class ShowAllAdminViewModel
    {
        public const int AdminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalAdminsCount { get; set; }

        public string? SearchTermEgn { get; set; }

        public string? SearchTermName { get; set; }

        public IEnumerable<DashboardAdminViewModel> Admins { get; set; } = new List<DashboardAdminViewModel>();
    }
}
