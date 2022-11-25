using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.LaboratoryPatient
{
    public class ResultViewModel
    {
        public string PatientName { get; set; } = null!;

        public string PatientEgn { get; set; } = null!;

        public int PatientGender { get; set; }

        public string Date { get; set; } = null!;

        public string WBC { get; set; }

        public string RBC { get; set; }

        public string Hgb { get; set; }

        public string Hct { get; set; }

        public string MCV { get; set; }

        public string MCH { get; set; }

        public string MCHC { get; set; }

        public string Plt { get; set; }

        public string UrinepH { get; set; }

        public string UrineGravity { get; set; }

    }
}
