namespace MedicalCenter.Core.Models.Review
{
    public class AllReceiveReviewViewModel
    {
        public string UserFullName { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = null!;

        public string ExaminationDate { get; set; } = null!;
    }
}
