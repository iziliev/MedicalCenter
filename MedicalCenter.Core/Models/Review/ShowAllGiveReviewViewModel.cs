using MedicalCenter.Core.Models.Administrator;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllGiveReviewViewModel
    {
        public const int ReviewPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalReviewsCount { get; set; }

        public IEnumerable<AllGiveReviewViewModel> Reviews { get; set; } = new List<AllGiveReviewViewModel>();
    }
}
