using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Examination
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; }

        [Required]
        public string UserPhoneNumber { get; set; } = null!;

        [Required]
        public string UserFullName { get; set; } = null!;

        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; } = null!;
        public Doctor Doctor { get; set; }

        [Required]
        public string DoctorFullName { get; set; } = null!;

        [Required]
        public string DoctorPhoneNumber { get; set; } = null!;

        [Required]
        public int SpecialityId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Hour { get; set; } = null!;

        [ForeignKey(nameof(Review))]
        public string? ReviewId { get; set; }
        public Review? Review { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsUserReviewedExamination { get; set; }
    }
}