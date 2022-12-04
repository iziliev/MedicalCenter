using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IReviewService
    {
        /// <summary>
        /// Creating review
        /// </summary>
        /// <param name="reviewModel"></param>
        Task CreateReviewAsync(ReviewViewModel reviewModel);

        /// <summary>
        /// All review
        /// </summary>
        /// <param name="speciality"></param>
        /// <param name="searchTermName"></param>
        /// <param name="searchTermRating"></param>
        /// <param name="currentPage"></param>
        /// <param name="reviewPerPage"></param>
        /// <returns></returns>
        Task<ShowAllReviewViewModel> GetAllReviewsAsync(
            string? speciality = null, 
            string? searchTermName = null, 
            string? searchTermRating = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// all review for doctor
        /// </summary>
        /// <param name="doctorId">record identificator</param>
        /// <param name="searchTerm"></param>
        /// <param name="currentPage"></param>
        /// <param name="reviewPerPage"></param>
        /// <returns></returns>
        Task<ShowAllReceiveReviewViewModel> GetReceiveReviewsByDoctorIdAsync(
            string doctorId, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// All reviews user
        /// </summary>
        /// <param name="userId">record identificator</param>
        /// <param name="speciality"></param>
        /// <param name="searchTermDate"></param>
        /// <param name="searchTermName"></param>
        /// <param name="currentPage"></param>
        /// <param name="reviewPerPage"></param>
        /// <returns></returns>
        Task<ShowAllGiveReviewViewModel> GetAllGiveReviewsByUserAsync(
            string userId, 
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
