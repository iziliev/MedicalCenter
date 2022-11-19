using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IReviewService
    {
        Task CreateReviewAsync(ReviewViewModel reviewModel);

        Task<ShowAllReviewViewModel> GetAllReviewsAsync(
            string? speciality = null, 
            string? searchTermName = null, 
            string? searchTermRating = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllReceiveReviewViewModel> GetReceiveReviewsByDoctorIdAsync(
            string doctorId, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllGiveReviewViewModel> GetAllGiveReviewsByUserAsync(
            string userId, 
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
