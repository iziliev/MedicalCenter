using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class WorkHour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Hour { get; set; } = null!;

        [ForeignKey(nameof(Shedule))]
        public int SheduleId { get; set; }
        public Shedule Shedule { get; set; }
    }
}
