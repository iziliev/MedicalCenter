using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedicalCenter.Infrastructure.Data.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.Laborant
{
    public class UploadTestResultViewModel
    {
        public string? Id { get; set; }

        public string LaboratoryPatientId { get; set; }

        public Infrastructure.Data.Models.LaboratoryPatient? LaboratoryPatient { get; set; }

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
