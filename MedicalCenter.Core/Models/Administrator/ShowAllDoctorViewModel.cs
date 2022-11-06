namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllDoctorViewModel
    {
        public const int DoctorsPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalDoctorsCount { get; set; }

        public IEnumerable<DashboardDoctorViewModel> Doctors { get; set; } = new List<DashboardDoctorViewModel>();
    }
}
