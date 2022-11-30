using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string? LaborantId { get; set; }
        public Laborant? Laborant { get; set; }

        public string? LaboratoryPatientId { get; set; }
        public LaboratoryPatient? LaboratoryPatient { get; set; }

        public string? AdministratorId { get; set; }
        public Administrator? Administrator { get; set; }

        public int GenderId { get; set; }

        public string? Role { get; set; }

        public string? JoinOnDate { get; set; }

        public ICollection<Examination> UserExaminations { get; set; } = new HashSet<Examination>();

        public ICollection<Review> UserReviews { get; set; } = new HashSet<Review>();
    }
}
