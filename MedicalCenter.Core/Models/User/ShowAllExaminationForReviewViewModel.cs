using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllExaminationForReviewViewModel
    {
        public const int ExaminationsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationsCount { get; set; }

        public string? SearchTermDate { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<DashboardExaminationForReviewViewModel> Examinations { get; set; } = new List<DashboardExaminationForReviewViewModel>();
    }
}
