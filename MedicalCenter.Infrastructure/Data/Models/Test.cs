using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Infrastructure.Data.Models
{
    public class Test
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(LaboratoryPatient))]
        public string LaboratoryPatientId { get; set; } = null!;
        public LaboratoryPatient LaboratoryPatient { get; set; }

        public DateTime TestDate { get; set; }

        public string? WBC { get; set; }

        public string? RBC { get; set; }

        public string? Hgb { get; set; }

        public string? Hct { get; set; }

        public string? MCV { get; set; }

        public string? MCH { get; set; }

        public string? MCHC { get; set; }

        public string? Plt { get; set; }

        public string? UrinepH { get; set; }

        public string? UrineGravity { get; set; }
    }
}
