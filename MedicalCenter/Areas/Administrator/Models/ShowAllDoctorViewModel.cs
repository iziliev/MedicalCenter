using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    public class ShowAllDoctorViewModel
    {
        public const int DoctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalDoctorsCount { get; set; }

        public string? SearchTermEgn { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardDoctorViewModel> Doctors { get; set; } = new List<DashboardDoctorViewModel>();
    }
}
