using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Review;
using MedicalCenter.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class ReviewServiceTests : UnitTestBase
    {
        private IReviewService reviewService;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            reviewService = new ReviewService(data);
        }

        [Test]
        public async Task CreateReviewAsync_ShouldCreateReview() 
        {
            //Arrange
            var model = new ReviewViewModel()
            {
                Content = "Best",CreatedOn = DateTime.Now,DoctorId = "1",ExaminationId = "2",Rating = 2,UserId = "1"
            };
            
            //Act
            await reviewService.CreateReviewAsync(model);
            var allReviews = await reviewService.GetAllReviewsAsync();

            //Assert
            Assert.NotNull(allReviews);
            Assert.AreEqual(allReviews.TotalReviewsCount, 2);
        }

        [Test]
        public async Task GetReceiveReviewsByDoctorIdAsync_ShouldReturnAllReviewForDoctor()
        {
            //Arrange
            
            //Act
            var allReviews = await reviewService.GetReceiveReviewsByDoctorIdAsync("1");

            var currentReview = allReviews.Reviews.ToList();

            //Assert
            Assert.NotNull(allReviews);
            Assert.AreEqual(allReviews.TotalReviewsCount, 1);
            Assert.AreEqual(currentReview[0].Content, "AAAAA");
        }

        [Test]
        public async Task GetAllGiveReviewsByUserAsync_ShouldReturnAllReviewUser()
        {
            //Arrange

            //Act
            var allReviews = await reviewService.GetAllGiveReviewsByUserAsync("5");

            var currentReview = allReviews.Reviews.ToList();

            //Assert
            Assert.NotNull(allReviews);
            Assert.AreEqual(allReviews.TotalReviewsCount, 1);
            Assert.AreEqual(currentReview[0].Content, "AAAAA");
        }
    }
}
