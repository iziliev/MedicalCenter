using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Core.Models.Review;
using MedicalCenter.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MedicalCenter.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateReview(string examinationId)
        {
            var examination = await reviewService.GetExamination(examinationId);
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
                var examination = await reviewService.GetExamination(reviewModel.ExaminationId);
                ViewData["Title"] = $"Оценка за прегледа при {examination.DoctorFullName} проведен на {examination.Date.ToString("dd.MM.yyyy")} {examination.Hour}";
                return View(reviewModel);
            }

            await reviewService.CreateReview(reviewModel);

            return RedirectToAction("ExaminationForFeedback", "User");
        }

        [HttpGet]
        public async Task<IActionResult> AllGiveReview(ShowAllGiveReviewViewModel query)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewData["Title"] = $"Всички оценки";

            var queryResult = await reviewService.GetAllGiveReviews(userId, query.CurrentPage,
                ShowAllGiveReviewViewModel.ReviewPerPage);

            ViewData["Title"] = $"Получени оценки";

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllReceiveReview(ShowAllReceiveReviewViewModel query)
        {
            var doctorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var queryResult = await reviewService.GetReceiveReviews(doctorId,query.CurrentPage,
                ShowAllReceiveReviewViewModel.ReviewPerPage);

            ViewData["Title"] = $"Получени оценки";

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllReview(ShowAllReviewViewModel query)
        {
            var queryResult = await reviewService.GetAllReviews(query.CurrentPage,
                ShowAllReviewViewModel.ReviewPerPage);

            ViewData["Title"] = "Всички оценки";

            query.TotalReviewsCount = queryResult.TotalReviewsCount;
            query.Reviews = queryResult.Reviews;

            return View(query);

        }
    }
}
