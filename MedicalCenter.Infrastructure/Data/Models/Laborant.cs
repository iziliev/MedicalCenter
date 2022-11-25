using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Laborant : User
    {
        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght)]
        public string Egn { get; set; } = null!;

        public bool IsOutOfCompany { get; set; } = false;

        public string? OutOnDate { get; set; }
    }
}
