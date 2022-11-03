namespace MedicalCenter.Core.Models.Dotor
{
    public class DoctorExaminationViewModel
    {
        public string ExaminationId { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Hour { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string UserFullName { get; set; } = null!;

         public string UserPhoneNumber { get; set; } = null!;
    }
}
