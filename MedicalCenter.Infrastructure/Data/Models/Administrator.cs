using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Administrator
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
