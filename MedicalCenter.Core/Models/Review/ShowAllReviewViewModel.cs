using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.Review
{
    public class ShowAllReviewViewModel
    {
        public const int ReviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalReviewsCount { get; set; }

        public string? SearchTermName { get; set; }

        public string? SearchTermRating { get; set; }

        public string? Speciality { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();

        public IEnumerable<AllReviewViewModel> Reviews { get; set; } = new List<AllReviewViewModel>();
    }
}
