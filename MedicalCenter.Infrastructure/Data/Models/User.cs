using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(UserConstants.FirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.LastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        public int GenderId { get; set; }

        public string? Role { get; set; }

        public string? JoinOnDate { get; set; }

        public ICollection<Examination> UserExaminations { get; set; } = new HashSet<Examination>();

        public ICollection<Review> UserReviews { get; set; } = new HashSet<Review>();
    }
}
