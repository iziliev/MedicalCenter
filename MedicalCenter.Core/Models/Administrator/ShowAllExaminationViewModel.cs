using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllExaminationViewModel
    {
        public const int ExaminationPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationCount { get; set; }

        public string? SearchTermName { get; set; }

        public string? Speciality { get; set; }

        public string? SearchTermDate { get; set; }

        public IEnumerable<Specialty> Specialities { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardExaminationViewModel> AllExamination { get; set; } = new List<DashboardExaminationViewModel>();
    }
}
