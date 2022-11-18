using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllDoctorViewModel
    {
        public const int DoctorsPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalDoctorsCount { get; set; }

        public string? SearchTermEgn { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardDoctorViewModel> Doctors { get; set; } = new List<DashboardDoctorViewModel>();
    }
}
