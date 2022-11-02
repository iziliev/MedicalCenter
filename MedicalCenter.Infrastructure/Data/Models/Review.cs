using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenter.Infrastructure.Data.Models
{   

    public class Review
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; } = null!;
        public Doctor Doctor { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Examination> Examinations { get; set; } = new HashSet<Examination>();
    }
}