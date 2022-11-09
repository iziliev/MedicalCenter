using MedicalCenter.Core.Models.Administrator;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllReceiveReviewViewModel
    {
        public const int ReviewPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalReviewsCount { get; set; }

        public IEnumerable<AllReceiveReviewViewModel> Reviews { get; set; } = new List<AllReceiveReviewViewModel>();
    }
}
