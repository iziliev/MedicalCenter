using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.User
{
    public class RegisterExternalViewModel
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredPhoneNumber)]
        [RegularExpression(UserConstants.PhoneMatch, ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Пол")]
        public int Gender { get; set; }

        public string? ReturnUrl { get; set; }

        public string? LoginProvider { get; set; }

        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
