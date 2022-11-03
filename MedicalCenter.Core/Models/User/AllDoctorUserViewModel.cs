using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Models.User
{
    public class AllDoctorUserViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Снимка")]
        public string ProfileImageUrl { get; set; } = null!;

        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        public string? SpecialityName { get; set; }

        public int SpecialtyId { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = null!;

    }
}
