using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.Laborant
{
    public class MainLaboratoryPatientViewModel
    {
        public string? Id { get; set; }

        [Required]
        [StringLength(UserConstants.UsernameMaxLenght, MinimumLength = UserConstants.UsernameMinLenght, ErrorMessage = UserConstants.UsernameError)]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.FirstNameMaxLenght, MinimumLength = UserConstants.FirstNameMinLenght, ErrorMessage = UserConstants.FirstNameError)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.LastNameMaxLenght, MinimumLength = UserConstants.LastNameMinLenght, ErrorMessage = UserConstants.LastNameError)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [RegularExpression(UserConstants.PhoneMatch, ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Пол")]
        public int Gender { get; set; }

        public string? Role { get; set; }

        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
