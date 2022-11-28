using MedicalCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Areas.Administrator.Models
{
    public class MainDoctorViewModel
    {
        public string? Id { get; set; }

        [Required]
        [StringLength(UserConstants.FirstNameMaxLenght, MinimumLength = UserConstants.FirstNameMinLenght, ErrorMessage = UserConstants.FirstNameError)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.LastNameMaxLenght, MinimumLength = UserConstants.LastNameMinLenght, ErrorMessage = UserConstants.LastNameError)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [Url]
        [Display(Name = "Снимка")]
        public string ProfileImageUrl { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.UsernameMaxLenght, MinimumLength = UserConstants.UsernameMinLenght, ErrorMessage = UserConstants.UsernameError)]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.EmailMaxLenght, MinimumLength = UserConstants.EmailMinLenght, ErrorMessage = UserConstants.EmailError)]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        public string? SpecialityName { get; set; }

        public int SpecialtyId { get; set; }

        [Required]
        [RegularExpression(UserConstants.PhoneMatch, ErrorMessage = UserConstants.PhoneError)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;


        [Display(Name = "Смяна")]
        public int SheduleId { get; set; }

        [Display(Name = "Пол")]
        public int Gender { get; set; }

        [Required]
        [StringLength(DoctorConstants.RepresentationMaxLenght, MinimumLength = DoctorConstants.RepresentationMinLenght, ErrorMessage = DoctorConstants.RepresentationError)]
        [Display(Name = "Кратко представяне")]
        public string Representation { get; set; } = null!;

        [Required]
        [StringLength(DoctorConstants.EducationMaxLenght, MinimumLength = DoctorConstants.RepresentationMinLenght, ErrorMessage = DoctorConstants.EducationError)]
        [Display(Name = "Образование и квалификации")]
        public string Education { get; set; } = null!;

        [Required]
        [StringLength(DoctorConstants.BiographyMaxLenght, MinimumLength = DoctorConstants.BiographyMinLenght, ErrorMessage = DoctorConstants.BiographyError)]
        [Display(Name = "Биография")]
        public string Biography { get; set; } = null!;

        public bool IsOutOfCompany { get; set; } = false;

        public string? OutOnDate { get; set; }

        public string? JoinOnDate { get; set; }

        public string? Role { get; set; }

        public IEnumerable<Shedule> Shedules { get; set; } = new HashSet<Shedule>();

        public IEnumerable<Specialty> Specialties { get; set; } = new HashSet<Specialty>();

        public IEnumerable<Gender> Genders { get; set; } = new HashSet<Gender>();
    }
}
