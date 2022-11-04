using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ModelErrorConstants.RequiredLogin)]
        [Display(Name = "Потребителско име/Email")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredPassword)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }
    }
}
