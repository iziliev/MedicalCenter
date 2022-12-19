using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Review;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            var user = await repository.GetByIdAsync<User>(reviewModel.UserId);
            var doctor = await repository.GetByIdAsync<Doctor>(reviewModel.DoctorId);
            var examination = await repository.GetByIdAsync<Examination>(reviewModel.ExaminationId);
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
                    DoctorFullName = $"Д-р {x.User.FirstName} {x.User.LastName}",
                    Rating = x.Rating
                })
                .ToListAsync();
        }

        public async Task<ShowAllReviewViewModel> GetAllReviewsAsync(
            string? speciality = null, 
            string? searchTermName = null, 
            string? searchTermRating = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var reviewsQuery = repository.All<Review>()
                .Include(d=>d.Doctor)
                .ThenInclude(s=>s.Specialty)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                reviewsQuery = reviewsQuery
                    .Where(d => d.Doctor.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                reviewsQuery = reviewsQuery
                    .Where(d => EF.Functions.Like(d.Doctor.User.FirstName, searchTermName) || EF.Functions.Like(d.Doctor.User.LastName, searchTermName));
            }

            if (string.IsNullOrEmpty(searchTermRating) == false)
            {
                var isNumber = int.TryParse(searchTermRating, out int rating);

                if (isNumber)
                {
                    reviewsQuery = reviewsQuery
                        .Where(d => d.Rating == rating);
                }              
            }

            var reviews = await reviewsQuery
                .OrderByDescending(x => x.CreatedOn)
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(d => new AllReviewViewModel
                {
                    Content = d.Content,
                    CreatedOn = d.CreatedOn.ToString("dd.MM.yyyy"),
                    DoctorFullName = $"{d.Doctor.User.FirstName} {d.Doctor.User.LastName}",
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

        public async Task<ShowAllReceiveReviewViewModel> GetReceiveReviewsByDoctorIdAsync(
            string doctorId, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var reviewsQuery = repository.AllReadonly<Examination>()
                .Include(d => d.User)
                .ThenInclude(x=>x.UserReviews)
                .Where(u => u.DoctorId == doctorId && u.IsUserReviewedExamination)
                .OrderByDescending(x=>x.Date)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var isDate = DateTime.TryParseExact(searchTerm, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime searchDate);

                if (isDate)
                {
                    reviewsQuery = reviewsQuery
                        .Where(y => y.Date == searchDate);
                }
            }

            var reviews = await reviewsQuery
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(x => new AllReceiveReviewViewModel
                {
                    Content = x.Review.Content,
                    CreatedOn = x.Review.CreatedOn.ToString("dd.MM.yyyy"),
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    Rating = x.Review.Rating,
                    ExaminationDate = $"{x.Date:dd.MM.yyyy} {x.Hour}"
                })
                .ToListAsync();

            return new ShowAllReceiveReviewViewModel
            {
                Reviews = reviews,
                TotalReviewsCount = reviewsQuery.Count()
            };
        }

        public async Task<ShowAllGiveReviewViewModel> GetAllGiveReviewsByUserAsync(
            string userId, 
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var reviewsQuery = repository.AllReadonly<Examination>()
                .Where(e=>!e.IsDeleted && e.UserId == userId && e.IsUserReviewedExamination)
                .Include(d => d.User)
                .Include(d=>d.Doctor)
                .ThenInclude(x => x.User.UserReviews)
                .OrderByDescending(x => x.Date)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                reviewsQuery = reviewsQuery
                    .Where(d => d.Doctor.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermDate) == false)
            {
                var isDateCorrect = DateTime.TryParseExact(searchTermDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime searchDate);

                if (isDateCorrect)
                {
                    reviewsQuery = reviewsQuery
                        .Where(d => d.Date == searchDate);
                }
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%";

                reviewsQuery = reviewsQuery
                    .Where(d => EF.Functions.Like(d.Doctor.User.FirstName.ToLower(), searchTermName) ||
                    EF.Functions.Like(d.Doctor.User.FirstName.ToLower(), searchTermName) ||
                    EF.Functions.Like(d.Doctor.User.LastName.ToLower(), searchTermName) ||
                    EF.Functions.Like(d.Doctor.User.LastName.ToLower(), searchTermName));
            }

            var reviews = await reviewsQuery
                .Skip((currentPage - 1) * reviewPerPage)
                .Take(reviewPerPage)
                .Select(x => new AllGiveReviewViewModel
                {
                    Content = x.Review.Content,
                    CreatedOn = x.Review.CreatedOn.ToString("dd.MM.yyyy"),
                    SpecialityName = x.Doctor.Specialty.Name,
                    DoctorFullName = $"{x.Doctor.User.FirstName} {x.Doctor.User.LastName}",
                    Rating = x.Review.Rating,
                    ExaminationDate = $"{x.Date:dd.MM.yyyy} {x.Hour}"
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
