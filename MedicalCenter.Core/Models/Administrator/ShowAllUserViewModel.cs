using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.Administrator
{
    public class ShowAllUserViewModel
    {
        public IEnumerable<DashboardUserViewModel> AllUsers { get; set; } = new HashSet<DashboardUserViewModel>();

        public int CountUser => this.AllUsers.Count();
    }
}
