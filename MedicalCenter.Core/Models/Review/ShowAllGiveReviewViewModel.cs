using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllGiveReviewViewModel
    {
        public const int ReviewPerPage = 5;

        public int CurrentPage { get; set; } = 1;

        public int TotalReviewsCount { get; set; }

        public string? SearchTermDate { get; set; }

        public string? SearchTermName { get; set; }

        public string? Specialty { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<AllGiveReviewViewModel> Reviews { get; set; } = new List<AllGiveReviewViewModel>();
    }
}
