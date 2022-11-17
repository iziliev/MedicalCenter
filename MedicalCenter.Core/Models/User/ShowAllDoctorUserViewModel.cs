using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.User
{
    public class ShowAllDoctorUserViewModel
    {
        public const int DoctorsPerPage = 4;

        [Display(Name = "Търсене по специалност")]
        public string? Specialty { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalDoctorsCount { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        [Display(Name = "Търсене по име на лекар")]
        public string? SearchTerm { get; set; }

        public IEnumerable<DashboardAllDoctorUserViewModel> Doctors { get; set; } = new List<DashboardAllDoctorUserViewModel>();
    }
}
