namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllUserViewModel
    {
        public const int UsersPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalUsersCount { get; set; }

        public IEnumerable<DashboardUserViewModel> AllUsers { get; set; } = new List<DashboardUserViewModel>();
    }
}
