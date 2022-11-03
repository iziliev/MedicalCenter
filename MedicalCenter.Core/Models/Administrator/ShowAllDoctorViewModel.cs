using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllDoctorViewModel
    {
        public IEnumerable<DashboardDoctorViewModel> AllDoctors { get; set; } = new HashSet<DashboardDoctorViewModel>();

        public int CountDoctor => this.AllDoctors.Count();
    }
}
