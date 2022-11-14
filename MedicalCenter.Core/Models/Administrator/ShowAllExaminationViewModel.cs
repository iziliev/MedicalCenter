namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllExaminationViewModel
    {
        public const int ExaminationPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationCount { get; set; }

        public IEnumerable<DashboardExaminationViewModel> AllExamination { get; set; } = new List<DashboardExaminationViewModel>();
    }
}
