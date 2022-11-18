namespace MedicalCenter.Core.Models.Review
{
    public class AllGiveReviewViewModel
    {
        public string DoctorFullName { get; set; } = null!;

        public string SpecialityName { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = null!;

        public string ExaminationDate { get; set; } = null!;
    }
}
