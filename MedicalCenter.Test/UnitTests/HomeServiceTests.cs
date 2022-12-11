using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.IsNotNull(statistic);
            Assert.AreEqual(statistic.AllUserCount, 2);
            Assert.AreEqual(statistic.BestExaminationCount, 1);
            Assert.AreEqual(statistic.AllExamination, 1);
        }
    }
}
