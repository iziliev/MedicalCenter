using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.Laborant
{
    public class CreateLaboratoryPatientViewModel: MainLaboratoryPatientViewModel
    {
        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght, MinimumLength = DoctorConstants.EgnMinMaxLenght, ErrorMessage = DoctorConstants.EgnError)]
        [Display(Name = "ЕГН")]
        public string Egn { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.PasswordMaxLenght, MinimumLength = UserConstants.PasswordMinLenght, ErrorMessage = UserConstants.PasswordError)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
    }
}
