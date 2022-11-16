using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.User
{

    public class RegisterViewModel
    {
        [Required(ErrorMessage = ModelErrorConstants.RequiredUsername)]
        [StringLength(UserConstants.UsernameMaxLenght, MinimumLength = UserConstants.UsernameMinLenght,ErrorMessage = UserConstants.UsernameError)]
        [Display(Name ="Потребителско име")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredEmail)]
        [StringLength(UserConstants.EmailMaxLenght, MinimumLength = UserConstants.EmailMinLenght,ErrorMessage = UserConstants.EmailError)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = ModelErrorConstants.RequiredFirstName)]
        [StringLength(UserConstants.FirstNameMaxLenght, MinimumLength = UserConstants.FirstNameMinLenght, ErrorMessage = UserConstants.FirstNameError)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = ModelErrorConstants.RequiredLastName)]
        [StringLength(UserConstants.LastNameMaxLenght, MinimumLength = UserConstants.LastNameMinLenght,ErrorMessage = UserConstants.LastNameError)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredPassword)]
        [StringLength(UserConstants.PasswordMaxLenght, MinimumLength = UserConstants.PasswordMinLenght,ErrorMessage = UserConstants.PasswordError)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredConfirmPassword)]
        [StringLength(UserConstants.PasswordMaxLenght, MinimumLength = UserConstants.PasswordMinLenght,ErrorMessage = UserConstants.PasswordError)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = UserConstants.ConfirmPasswordError)]
        [Display(Name = "Поврори парола")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = ModelErrorConstants.RequiredPhoneNumber)]
        [RegularExpression(UserConstants.PhoneMatch,ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Пол")]
        public int Gender { get; set; }

        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
