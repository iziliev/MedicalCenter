using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllDoctorUserViewModel
    {
        public const int DoctorsPerPage = DataConstants.PagingConstants.ShowDoctorPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public string? Specialty { get; set; }

        public int TotalDoctorsCount { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public string? SearchTerm { get; set; }

        public IEnumerable<DashboardAllDoctorUserViewModel> Doctors { get; set; } = new List<DashboardAllDoctorUserViewModel>();
    }
}
