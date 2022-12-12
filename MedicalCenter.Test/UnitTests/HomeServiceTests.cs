using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class HomeServiceTests :UnitTestBase
    {
        private static IHomeService homeService;

        [OneTimeSetUp]
        public void SetUp()
        {
            homeService = new HomeService(data);
        }

        [Test]
        public void Statistics_ShouldReturnStatistic()
        {
            //Arrange
            //Act
            var statistic = homeService.Statistics();

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(statistic, Is.Not.Null);
                Assert.That(statistic.AllUserCount, Is.EqualTo(2));
                Assert.That(statistic.BestExaminationCount, Is.EqualTo(1));
                Assert.That(statistic.AllExamination, Is.EqualTo(1));
            });
        }
    }
}
