using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IReviewService
    {
        Task CreateReviewAsync(ReviewViewModel reviewModel);

        Task<Examination> GetExaminationByIdAsync(string examinationId);

        Task<User> GetUserByUserIdAsync(string userId);

        Task<Doctor> GetDoctorByIdAsync(string doctorId);

        Task<ShowAllReviewViewModel> GetAllReviewsAsync(string? speciality = null, string? searchTermName = null, string? searchTermRating = null,int currentPage = 1, int reviewPerPage = 6);

        Task<ShowAllReceiveReviewViewModel> GetReceiveReviewsByDoctorIdAsync(string doctorId, string? searchTerm = null, int currentPage = 1, int reviewPerPage = 6);

        Task<ShowAllGiveReviewViewModel> GetAllGiveReviewsByUserAsync(string userId, string? speciality = null, string? searchTermDate = null, string? searchTermName = null, int currentPage = 1, int reviewPerPage = 6);
    }
}
