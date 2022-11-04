namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllDoctorViewModel
    {
        public IEnumerable<DashboardDoctorViewModel> AllDoctors { get; set; } = new HashSet<DashboardDoctorViewModel>();

        public int CountDoctor => this.AllDoctors.Count();
    }
}
