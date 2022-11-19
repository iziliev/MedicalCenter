using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Global;
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
        public const int DoctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.ShowPerPageConstant;

        public string? Specialty { get; set; }

        public int TotalDoctorsCount { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public string? SearchTerm { get; set; }

        public IEnumerable<DashboardAllDoctorUserViewModel> Doctors { get; set; } = new List<DashboardAllDoctorUserViewModel>();
    }
}
