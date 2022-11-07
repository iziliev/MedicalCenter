using MedicalCenter.Core.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllDoctorUserViewModel
    {
        public const int DoctorsPerPage = 4;

        public int CurrentPage { get; set; } = 1;

        public int TotalDoctorsCount { get; set; }

        public IEnumerable<DashboardAllDoctorUserViewModel> Doctors { get; set; } = new List<DashboardAllDoctorUserViewModel>();
    }
}
