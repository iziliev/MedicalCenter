using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllExaminationForReviewViewModel
    {
        public const int ExaminationsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalExaminationsCount { get; set; }

        public string? SearchTermDate { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardExaminationForReviewViewModel> Examinations { get; set; } = new List<DashboardExaminationForReviewViewModel>();
    }
}
