namespace MedicalCenter.Core.Models.User
{
    public class DashboardExaminationForReviewViewModel
    {
        public string ExaminationId { get; set; } = null!;

        public string DateAndHour { get; set; } = null!;

        public string DoctorId { get; set; } = null!;

        public string DoctorNameAndSpecialty { get; set; } = null!;

        public bool IsReviewed { get; set; } = false;
    }
}
