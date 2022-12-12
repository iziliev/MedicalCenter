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
        public void SetUp()
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
            var allReviewsSpec = await reviewService.GetAllReviewsAsync("A");
            var allReviewsSpecName = await reviewService.GetAllReviewsAsync("A","Doctor1");
            var allReviewsSpecNameRating = await reviewService.GetAllReviewsAsync("A", "Doctor1","2");

            var allReviewsNotExist = await reviewService.GetAllReviewsAsync("A", "Doctor1","1");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(allReviews.TotalReviewsCount, Is.EqualTo(2));
                Assert.That(allReviewsSpec.TotalReviewsCount, Is.EqualTo(2));
                Assert.That(allReviewsSpecName.TotalReviewsCount, Is.EqualTo(2));
                Assert.That(allReviewsSpecNameRating.TotalReviewsCount, Is.EqualTo(1));
                Assert.That(allReviewsNotExist.TotalReviewsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetReceiveReviewsByDoctorIdAsync_ShouldReturnAllReviewForDoctor()
        {
            //Arrange
            
            //Act
            var allReviews = await reviewService.GetReceiveReviewsByDoctorIdAsync("1");
            var allReviewsName = await reviewService.GetReceiveReviewsByDoctorIdAsync("2", "08.08.2022");
            var allReviewsNotExist = await reviewService.GetReceiveReviewsByDoctorIdAsync("5", "08.08.2022");

            var currentReview = allReviews.Reviews.ToList();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(allReviews.TotalReviewsCount, Is.EqualTo(1));
                Assert.That(allReviewsName.TotalReviewsCount, Is.EqualTo(0));
                Assert.That(allReviewsNotExist.TotalReviewsCount, Is.EqualTo(0));
                Assert.That(currentReview[0].Content, Is.EqualTo("Best"));
            });
        }

        [Test]
        public async Task GetAllGiveReviewsByUserAsync_ShouldReturnAllReviewUser()
        {
            //Arrange

            //Act
            var allReviews = await reviewService.GetAllGiveReviewsByUserAsync("5");
            var allReviewsSpec = await reviewService.GetAllGiveReviewsByUserAsync("5","A");
            var allReviewsDate = await reviewService.GetAllGiveReviewsByUserAsync("5","A","08.08.2022");
            var allReviewsName = await reviewService.GetAllGiveReviewsByUserAsync("5", "A", "08.08.2022","Doctor1");
            var allReviewsNotExist = await reviewService.GetAllGiveReviewsByUserAsync("5", "R");

            var currentReview = allReviews.Reviews.ToList();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(allReviews.TotalReviewsCount, Is.EqualTo(1));
                Assert.That(allReviewsSpec.TotalReviewsCount, Is.EqualTo(1));
                Assert.That(allReviewsDate.TotalReviewsCount, Is.EqualTo(0));
                Assert.That(allReviewsName.TotalReviewsCount, Is.EqualTo(0));
                Assert.That(allReviewsNotExist.TotalReviewsCount, Is.EqualTo(0));
                Assert.That(currentReview[0].Content, Is.EqualTo("Best"));
            });
        }

        [Test]
        public async Task GetAllToReviewsByUserIdAsync_ShouldReturnToReview()
        {
            //Arrange

            //Act
            var allReviews = await reviewService.GetAllToReviewsByUserIdAsync("5");

            //Assert
            Assert.That(allReviews.Count(), Is.EqualTo(1));
        }
    }
}
