using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Shedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
