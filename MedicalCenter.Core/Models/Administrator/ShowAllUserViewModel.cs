using MedicalCenter.Infrastructure.Data.Global;

namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllUserViewModel
    {
        public const int UsersPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalUsersCount { get; set; }

        public string? SearchTermEmail { get; set; }

        public string? SearchTermName { get; set; }

        public IEnumerable<DashboardUserViewModel> AllUsers { get; set; } = new List<DashboardUserViewModel>();
    }
}
