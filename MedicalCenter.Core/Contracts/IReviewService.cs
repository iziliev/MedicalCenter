using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IReviewService
    {
        Task CreateReview(ReviewViewModel reviewModel);

        Task<Examination> GetExamination(string examinationId);

        Task<User> GetUser(string userId);

        Task<Doctor> GetDoctor(string doctorId);

        Task<IEnumerable<AllGiveReviewViewModel>> GetAllReviews(string userId);

        Task<IEnumerable<AllReceiveReviewViewModel>> GetReceiveReviews(string doctorId);

        Task<IEnumerable<AllReviewViewModel>> GetAllReviews();
    }
}
