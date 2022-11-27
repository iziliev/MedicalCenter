using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class LaboratoryPatient : User
    {
        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght)]
        public string Egn { get; set; } = null!;

        public ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    }
}
