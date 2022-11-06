using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateReview(ReviewViewModel reviewModel)
        {
            var user = await GetUser(reviewModel.UserId);
            var doctor = await GetDoctor(reviewModel.DoctorId);
            var examination = await GetExamination(reviewModel.ExaminationId);
            var review = new Review
            {
                Content = reviewModel.Content,
                CreatedOn = DateTime.Now,
                DoctorId = reviewModel.DoctorId,
                Rating = reviewModel.Rating,
                UserId = reviewModel.UserId,
                Doctor = doctor,
                User = user
            };

            examination.IsUserReviewedExamination = true;

            await repository.AddAsync(review);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllGiveReviewViewModel>> GetAllReviews(string userId)
        {
            return await repository.All<Review>()
                .Include(d=>d.Doctor)
                .Where(u=>u.UserId == userId)
                .Select(x=>new AllGiveReviewViewModel
                {
                    Content=x.Content,
                    CreatedOn=x.CreatedOn.ToString("dd.MM.yyyy"),
                    DoctorFullName=$"Д-р {x.Doctor.FirstName} {x.Doctor.LastName}",
                    Rating = x.Rating
                }).ToListAsync();
        }

        public async Task<ShowAllReviewViewModel> GetAllReviews(int currentPage = 1, int reviewPerPage = 6)
        {
            var reviewsQuery = repository.All<Review>()
                .AsQueryable();

            var reviews = await reviewsQuery
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(d => new AllReviewViewModel
                {
                    Content = d.Content,
                    CreatedOn = d.CreatedOn.ToString("dd.MM.yyyy"),
                    DoctorFullName = $"{d.Doctor.FirstName} {d.Doctor.LastName}",
                    Rating = d.Rating,
                    UserFullName = $"{d.User.FirstName} {d.User.LastName}"
                })
                .ToListAsync();

            return new ShowAllReviewViewModel
            {
                Reviews = reviews,
                TotalReviewsCount = reviewsQuery.Count()
            };
        }

        public async Task<Doctor> GetDoctor(string doctorId)
        {
            return await repository.All<Doctor>()
                .Where(d => d.Id == doctorId)
                .FirstOrDefaultAsync();
        }

        public async Task<Examination> GetExamination(string examinationId)
        {
            return await repository.All<Examination>()
                .Where(e => e.Id == examinationId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllReceiveReviewViewModel>> GetReceiveReviews(string doctorId)
        {
            return await repository.All<Review>()
                .Include(d => d.User)
                .Where(u => u.DoctorId == doctorId)
                .Select(x => new AllReceiveReviewViewModel
                {
                    Content = x.Content,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy"),
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    Rating = x.Rating
                }).ToListAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await repository.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
