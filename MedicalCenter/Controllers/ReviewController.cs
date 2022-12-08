using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Review;
using MedicalCenter.Extensions;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;
        private readonly IDoctorService doctorService;

        public ReviewController(
            IReviewService _reviewService, 
            IGlobalService _globalService,
            IRepository _repository,
            IDoctorService _doctorService)
        {
            reviewService = _reviewService;
            globalService = _globalService;
            repository = _repository;
            doctorService = _doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateReview(string examinationId)
        {
            var examination = await repository.GetByIdAsync<Examination>(examinationId);
            var reviewModel = new ReviewViewModel();
            reviewModel.ExaminationId=examinationId;
            reviewModel.UserId = examination.UserId;
            reviewModel.DoctorId = examination.DoctorId;
            ViewData["Title"] = $"Оценка за прегледа при {examination.DoctorFullName} проведен на {examination.Date.ToString("dd.MM.yyyy")} {examination.Hour}";
            return View(reviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewViewModel reviewModel)
        {
            if (!ModelState.IsValid)
            {
                var examination = await repository.GetByIdAsync<Examination>(reviewModel.ExaminationId);
                ViewData["Title"] = $"Оценка за прегледа при {examination.DoctorFullName} проведен на {examination.Date.ToString("dd.MM.yyyy")} {examination.Hour}";
                return View(reviewModel);
            }

            await reviewService.CreateReviewAsync(reviewModel);

            return RedirectToAction("ExaminationForFeedback", "User");
        }

        [HttpGet]
        public async Task<IActionResult> AllGiveReview(ShowAllGiveReviewViewModel query)
        {
            var userId = User.Id();

            ViewData["Title"] = $"Всички оценки";

            var queryResult = await reviewService.GetAllGiveReviewsByUserAsync(
                userId, 
                query.Specialty,
                query.SearchTermDate,
                query. SearchTermName,
                query.CurrentPage,
                ShowAllGiveReviewViewModel.ReviewPerPage);

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllReceiveReview([FromQuery]ShowAllReceiveReviewViewModel query)
        {
            var doctor = await doctorService.GetDoctorByIdAsync(User.Id());
            
            var queryResult = await reviewService.GetReceiveReviewsByDoctorIdAsync(
                doctor.Id,
                query.SearchTerm,
                query.CurrentPage,
                ShowAllReceiveReviewViewModel.ReviewPerPage);

            ViewData["Title"] = $"Получени оценки";

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllReview([FromQuery]ShowAllReviewViewModel query)
        {
            var queryResult = await reviewService.GetAllReviewsAsync(
                query.Speciality,
                query.SearchTermName,
                query.SearchTermRating,
                query.CurrentPage,
                ShowAllReviewViewModel.ReviewPerPage);

            ViewData["Title"] = "Всички оценки";

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;
            query.Specialties = await globalService.GetSpecialtiesAsync();
            return View(query);

        }
    }
}
