using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Core.Models.User
{

    public class BookExaminationViewModel
    {
        
        public string DoctorFullName { get; set; } = null!;

        [Required]
        public string Date { get; set; } = null!;

        [Required]
         public string Hour { get; set; } = null!;

        [Required]
        public string DoctorId { get; set; } = null!;

        public string? Representation { get; set; }

        public string? Education { get; set; }

        public string? Biography { get; set; }

        public string? ProfileImage { get; set; } 

        public string? SpecialityName { get; set; }

        public IEnumerable<string> WorkHours { get; set; } = new List<string>();
    }

}
