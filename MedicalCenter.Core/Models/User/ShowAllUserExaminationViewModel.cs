using MedicalCenter.Core.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllUserExaminationViewModel
    {
        public const int ExaminationsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalExaminationCount { get; set; }

        public IEnumerable<DashboardUserExaminationViewModel> Examinations { get; set; } = new List<DashboardUserExaminationViewModel>();
    }
}
