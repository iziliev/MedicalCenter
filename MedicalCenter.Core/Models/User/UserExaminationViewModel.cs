namespace MedicalCenter.Models.User
{

    public class UserExaminationViewModel
    {
        public string ExaminationId { get; set; } = null!;


        public string Date { get; set; } = null!;

        public string Hour { get; set; } = null!;


        public string DoctorId { get; set; } = null!;

        public string DoctorFullName { get; set; } = null!;

        public string DoctorPhoneNumber { get; set; } = null!;

        public string Specialty { get; set; } = null!;
    }
}