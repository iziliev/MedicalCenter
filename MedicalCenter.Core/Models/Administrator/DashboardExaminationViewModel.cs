namespace MedicalCenter.Core.Models.Administrator
{
    public class DashboardExaminationViewModel
    {
        public string? DoctorId { get; set; }

        public string DoctorFullName { get; set; } = null!;

        public string? SpecialityName { get; set; }

        public int SpecialityId { get; set; }

        public string? PatientId { get; set; }

        public string PatientFullName { get; set; } = null!;

        public string ExaminationDate { get; set; } = null!;

        public string ExaminationHour { get; set; } = null!;
    }
}
