using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllUserExaminationViewModel
    {
        public int StatistilAllExaminationCount { get; set; }

        public const int ExaminationsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationCount { get; set; }

        public string? SearchTermDate { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardUserExaminationViewModel> Examinations { get; set; } = new List<DashboardUserExaminationViewModel>();
    }
}
