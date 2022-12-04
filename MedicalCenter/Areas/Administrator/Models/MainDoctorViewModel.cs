using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Doctor view model
    /// </summary>
    public class MainDoctorViewModel
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
        /// Profile image
        /// </summary>
        [Required]
        [Url]
        [Display(Name = "Снимка")]
        public string ProfileImageUrl { get; set; } = null!;

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
        /// Speciality name
        /// </summary>
        public string? SpecialityName { get; set; }

        /// <summary>
        /// Speciality id
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [RegularExpression(UserConstants.PhoneMatch, ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Shedul id
        /// </summary>
        [Display(Name = "Смяна")]
        public int SheduleId { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [Display(Name = "Пол")]
        public int Gender { get; set; }

        /// <summary>
        /// Representation
        /// </summary>
        [Required]
        [StringLength(DoctorConstants.RepresentationMaxLenght, MinimumLength = DoctorConstants.RepresentationMinLenght, ErrorMessage = DoctorConstants.RepresentationError)]
        [Display(Name = "Кратко представяне")]
        public string Representation { get; set; } = null!;

        /// <summary>
        /// Education
        /// </summary>
        [Required]
        [StringLength(DoctorConstants.EducationMaxLenght, MinimumLength = DoctorConstants.RepresentationMinLenght, ErrorMessage = DoctorConstants.EducationError)]
        [Display(Name = "Образование и квалификации")]
        public string Education { get; set; } = null!;

        /// <summary>
        /// Biography
        /// </summary>
        [Required]
        [StringLength(DoctorConstants.BiographyMaxLenght, MinimumLength = DoctorConstants.BiographyMinLenght, ErrorMessage = DoctorConstants.BiographyError)]
        [Display(Name = "Биография")]
        public string Biography { get; set; } = null!;

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
        /// Collection shedules
        /// </summary>
        public IEnumerable<Shedule> Shedules { get; set; } = new HashSet<Shedule>();

        /// <summary>
        /// Collection specialities
        /// </summary>
        public IEnumerable<Specialty> Specialties { get; set; } = new HashSet<Specialty>();

        /// <summary>
        /// Collection genders
        /// </summary>
        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
