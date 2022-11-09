using MedicalCenter.Core.Models.Administrator;
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

        public IEnumerable<DashboardExaminationForReviewViewModel> Examinations { get; set; } = new List<DashboardExaminationForReviewViewModel>();
    }
}
