using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Core.Models.Review
{
    public class ReviewViewModel
    {
        [Required]
        public string ExaminationId { get; set; } = null!;

        [Required]
        [StringLength(ReviewConstants.MaxContent,MinimumLength = ReviewConstants.MinContent)]
        public string Content { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string DoctorId { get; set; } = null!;

        [Range(ReviewConstants.MinRating,ReviewConstants.MaxRating)]
        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
