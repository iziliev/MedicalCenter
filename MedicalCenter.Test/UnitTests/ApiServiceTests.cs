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
            Assert.IsNotNull(statistic);
            Assert.AreEqual(statistic.AllFutureExamination, 1);
            Assert.AreEqual(statistic.AllPastExamination, 1);
            Assert.AreEqual(statistic.AllTest,1);
        }

        [Test]
        public async Task GetStatisticAdminLaboratory_ShouldReturnStatistic()
        {
            //Arrange
            //Act
            var statistic = await apiService.GetStatisticAdminLaboratory();

            //Assert
            Assert.IsNotNull(statistic);
            Assert.AreEqual(statistic.AllTest, 1);
        }

        [Test]
        public async Task GetStatisticLaborant_ShouldReturnLaborantSattistic()
        {
            //Arrange
            //Act
            var statistic = await apiService.GetStatisticLaborant();

            //Assert
            Assert.IsNotNull(statistic);
            Assert.AreEqual(statistic.AllTest, 1);
            Assert.AreEqual(statistic.AllUserCount, 1);
        }
    }
}
