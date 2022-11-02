using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
