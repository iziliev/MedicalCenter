using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.LaboratoryPatient
{
    public class LoginPatientViewModel
    {
        [Required(ErrorMessage = DoctorConstants.EgnError)]
        [Display(Name = "ЕГН")]
        public string Egn { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredPassword)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
    }
}
