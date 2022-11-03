using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.Administrator
{
    public class SearchDoctorViewModel
    {
        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght, MinimumLength = DoctorConstants.EgnMinMaxLenght, ErrorMessage = DoctorConstants.EgnError)]
        [Display(Name = "ЕГН")]
        public string Egn { get; set; } = null!;
    }
}
