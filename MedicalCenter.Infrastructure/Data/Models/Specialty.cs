using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Specialty
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
