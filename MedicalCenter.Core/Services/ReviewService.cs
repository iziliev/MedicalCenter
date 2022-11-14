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

        public async Task CreateReviewAsync(ReviewViewModel reviewModel)
        {
            var user = await GetUserByUserIdAsync(reviewModel.UserId);
            var doctor = await GetDoctorByIdAsync(reviewModel.DoctorId);
            var examination = await GetExaminationByIdAsync(reviewModel.ExaminationId);
            var review = new Review
            {
                Content = reviewModel.Content,
                CreatedOn = DateTime.Now,
                DoctorId = reviewModel.DoctorId,
                Rating = reviewModel.Rating,
                UserId = reviewModel.UserId,
                Doctor = doctor,
                User = user,
            };

            await repository.AddAsync(review);
            await repository.SaveChangesAsync();

            examination.IsUserReviewedExamination = true;
            examination.ReviewId = review.Id;
            examination.Review = review;

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllGiveReviewViewModel>> GetAllToReviewsByUserIdAsync(string userId)
        {
            return await repository.All<Review>()
                .Include(d => d.Doctor)
                .ThenInclude(s=>s.Specialty)
                .Where(u => u.UserId == userId)
                .Select(x => new AllGiveReviewViewModel
                {
                    Content = x.Content,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy"),
                    SpecialityName = x.Doctor.Specialty.Name,
                    DoctorFullName = $"Д-р {x.Doctor.FirstName} {x.Doctor.LastName}",
                    Rating = x.Rating
                })
                .ToListAsync();
        }

        public async Task<ShowAllReviewViewModel> GetAllReviewsAsync(int currentPage = 1, int reviewPerPage = 6)
        {
            var reviewsQuery = repository.All<Review>()
                .AsQueryable();

            var reviews = await reviewsQuery
                .OrderByDescending(x => x.CreatedOn)
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

        public async Task<Doctor> GetDoctorByIdAsync(string doctorId)
        {
            return await repository.All<Doctor>()
                .Where(d => d.Id == doctorId)
                .FirstOrDefaultAsync();
        }

        public async Task<Examination> GetExaminationByIdAsync(string examinationId)
        {
            return await repository.All<Examination>()
                .Where(e => e.Id == examinationId)
                .FirstOrDefaultAsync();
        }

        public async Task<ShowAllReceiveReviewViewModel> GetReceiveReviewsByDoctorIdAsync(string doctorId,int currentPage = 1, int reviewPerPage = 6)
        {
            var reviewsQuery = repository.All<Review>()
                .Include(d => d.User)
                .Where(u => u.DoctorId == doctorId)
                .AsQueryable();

            var reviews = await reviewsQuery
                .OrderByDescending(d => d.CreatedOn)
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(x => new AllReceiveReviewViewModel
                {
                    Content = x.Content,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy"),
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    Rating = x.Rating
                })
                .ToListAsync();

            return new ShowAllReceiveReviewViewModel
            {
                Reviews = reviews,
                TotalReviewsCount = reviewsQuery.Count()
            };
        }

        public async Task<User> GetUserByUserIdAsync(string userId)
        {
            return await repository.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<ShowAllGiveReviewViewModel> GetAllGiveReviewsByUserAsync(string userId, int currentPage = 1, int reviewPerPage = 6)
        {
            var reviewsQuery = repository.All<Review>()
                .Include(u => u.Doctor)
                .ThenInclude(s=>s.Specialty)
                .OrderByDescending(u => u.CreatedOn)
                .Where(u => u.UserId == userId)
                .AsQueryable();

            var reviews = await reviewsQuery
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(x => new AllGiveReviewViewModel
                {
                    Content = x.Content,
                    CreatedOn = x.CreatedOn.ToString("dd.MM.yyyy"),
                    SpecialityName = x.Doctor.Specialty.Name,
                    DoctorFullName = $"{x.Doctor.FirstName} {x.Doctor.LastName}",
                    Rating = x.Rating
                })
                .ToListAsync();

            return new ShowAllGiveReviewViewModel
            {
                Reviews = reviews,
                TotalReviewsCount = reviewsQuery.Count()
            };
        }
    }
}
