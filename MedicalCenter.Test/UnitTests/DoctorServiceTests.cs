using MedicalCenter.Areas.Administrator.Services;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class DoctorServiceTests:UnitTestBase
    {
        private IDoctorService doctorService;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            doctorService = new DoctorService(data);
        }

        [Test]
        public async Task GetAllExaminationAsync_ShouldReturnAllExamination()
        {
            //Arrange

            //Act
            var doctor = await doctorService.GetDoctorByIdAsync("2");
            var examinations = await doctorService.GetAllExaminationAsync(doctor);

            //Assert
            Assert.NotNull(examinations);
            Assert.AreEqual(examinations.Count(), 1);
            Assert.AreEqual(doctor.User.FirstName, "Doctor1");
        }

        [Test]
        public async Task GetDoctorStatisticsAsync_ShouldReturnStatistic()
        {
            //Arrange

            //Act
            var doctor = await doctorService.GetDoctorByIdAsync("2");
            var statistic = await doctorService.GetDoctorStatisticsAsync(doctor);

            //Assert
            Assert.NotNull(statistic);
            Assert.AreEqual(statistic.Rating, 4);
        }

        [Test]
        public async Task GetAllDoctorExaminationAsync_ReturnDoctorExaminations()
        {
            //Arrange

            //Act
            var examination = await doctorService.GetAllDoctorExaminationAsync("1");

            //Assert
            Assert.NotNull(examination);
            Assert.AreEqual(examination.TotalExaminationCount, 1);
        }
    }
}
