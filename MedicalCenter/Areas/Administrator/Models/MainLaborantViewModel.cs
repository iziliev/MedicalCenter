using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Laborant model
    /// </summary>
    public class MainLaborantViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required]
        [StringLength(UserConstants.FirstNameMaxLenght, MinimumLength = UserConstants.FirstNameMinLenght, ErrorMessage = UserConstants.FirstNameError)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name
        /// </summary>
        [Required]
        [StringLength(UserConstants.LastNameMaxLenght, MinimumLength = UserConstants.LastNameMinLenght, ErrorMessage = UserConstants.LastNameError)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Username
        /// </summary>
        [Required]
        [StringLength(UserConstants.UsernameMaxLenght, MinimumLength = UserConstants.UsernameMinLenght, ErrorMessage = UserConstants.UsernameError)]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [StringLength(UserConstants.EmailMaxLenght, MinimumLength = UserConstants.EmailMinLenght, ErrorMessage = UserConstants.EmailError)]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [RegularExpression(UserConstants.PhoneMatch, ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Gender
        /// </summary>
        [Display(Name = "Пол")]
        public int Gender { get; set; }

        /// <summary>
        /// Out from company
        /// </summary>
        public bool IsOutOfCompany { get; set; } = false;

        /// <summary>
        /// Out date
        /// </summary>
        public string? OutOnDate { get; set; }

        /// <summary>
        /// Join date
        /// </summary>
        public string? JoinOnDate { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Collection genders
        /// </summary>
        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
