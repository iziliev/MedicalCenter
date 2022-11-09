﻿using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IReviewService
    {
        Task CreateReview(ReviewViewModel reviewModel);

        Task<Examination> GetExamination(string examinationId);

        Task<User> GetUser(string userId);

        Task<Doctor> GetDoctor(string doctorId);

        Task<ShowAllReviewViewModel> GetAllReviews(int currentPage = 1, int reviewPerPage = 6);

        Task<ShowAllReceiveReviewViewModel> GetReceiveReviews(string doctorId,int currentPage = 1, int reviewPerPage = 6);

        Task<ShowAllGiveReviewViewModel> GetAllGiveReviews(string userId, int currentPage = 1, int reviewPerPage = 6);
    }
}
