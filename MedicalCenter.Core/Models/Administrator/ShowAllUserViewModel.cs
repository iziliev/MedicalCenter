namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllUserViewModel
    {
        public IEnumerable<DashboardUserViewModel> AllUsers { get; set; } = new HashSet<DashboardUserViewModel>();

        public int CountUser => this.AllUsers.Count();
    }
}
