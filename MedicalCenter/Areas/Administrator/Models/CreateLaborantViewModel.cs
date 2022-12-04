﻿using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Model to create laborant
    /// </summary>
    public class CreateLaborantViewModel : MainLaborantViewModel
    {
        /// <summary>
        /// Egn
        /// </summary>
        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght, MinimumLength = DoctorConstants.EgnMinMaxLenght, ErrorMessage = DoctorConstants.EgnError)]
        [Display(Name = "ЕГН")]
        public string Egn { get; set; } = null!;

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [StringLength(UserConstants.PasswordMaxLenght, MinimumLength = UserConstants.PasswordMinLenght, ErrorMessage = UserConstants.PasswordError)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
    }
}
