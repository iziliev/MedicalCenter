using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class ApiServiceTests : UnitTestBase
    {
        private IApiService apiService;

        [OneTimeSetUp]
        public void SetUp()
        {
            apiService = new ApiService(data);
        }

        [Test]
        public async Task GetStatisticHome_ShouldReturnStatistic()
        {
            //Arrange

            //Act
            var statistic = await apiService.GetStatisticHome();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(statistic.AllFutureExamination, Is.EqualTo(1));
                Assert.That(statistic.AllPastExamination, Is.EqualTo(1));
                Assert.That(statistic.AllTest, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetStatisticAdminLaboratory_ShouldReturnStatistic()
        {
            //Arrange
            //Act
            var statistic = await apiService.GetStatisticAdminLaboratory();

            //Assert
            Assert.That(statistic.AllTest, Is.EqualTo(1));
        }

        [Test]
        public async Task GetStatisticLaborant_ShouldReturnLaborantSattistic()
        {
            //Arrange
            //Act
            var statistic = await apiService.GetStatisticLaborant();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(statistic.AllTest, Is.EqualTo(1));
                Assert.That(statistic.AllUserCount, Is.EqualTo(1));
            });
        }

    }
}
