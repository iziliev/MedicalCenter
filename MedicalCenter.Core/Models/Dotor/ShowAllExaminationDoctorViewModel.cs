using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Core.Models.Dotor
{
    public class ShowAllExaminationDoctorViewModel
    {
        public const int ExaminationPerPage = 6;

        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationCount { get; set; }

        public IEnumerable<DashboardDoctorExaminationViewModel> AllExamination { get; set; } = new List<DashboardDoctorExaminationViewModel>();

    }
}
