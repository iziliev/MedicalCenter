namespace MedicalCenter.Core.Models.Review
{
    public class AllReviewViewModel
    {
        public string UserFullName { get; set; } = null!;

        public string DoctorFullName { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = null!;
    }
}
