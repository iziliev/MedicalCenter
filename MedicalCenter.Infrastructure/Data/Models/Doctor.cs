using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Doctor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public string ProfileImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Specialty))]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        [Required]
        [StringLength(DoctorConstants.RepresentationMaxLenght)]
        public string Representation { get; set; } = null!;

        [Required]
        [StringLength(DoctorConstants.EducationMaxLenght)]
        public string Education { get; set; } = null!;

        [Required]
        [StringLength(DoctorConstants.BiographyMaxLenght)]
        public string Biography { get; set; } = null!;

        public string? OutOnDate { get; set; }

        [Required]
        [StringLength(DoctorConstants.EgnMinMaxLenght)]
        public string Egn { get; set; } = null!;

        [ForeignKey(nameof(Shedule))]
        public int SheduleId { get; set; }
        public Shedule Shedule { get; set; }

        public ICollection<Examination> DoctorExaminations { get; set; } = new HashSet<Examination>();

        public ICollection<Review> DoctorReviews { get; set; } = new HashSet<Review>();
    }
}
