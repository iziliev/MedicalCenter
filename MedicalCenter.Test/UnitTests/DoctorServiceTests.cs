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
        public void SetUp()
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
            Assert.Multiple(() =>
            {
                Assert.That(examinations, Is.Not.Null);
                Assert.That(examinations.Count(), Is.EqualTo(1));
                Assert.That(doctor.User.FirstName, Is.EqualTo("Doctor1"));
            });
        }

        [Test]
        public async Task GetDoctorStatisticsAsync_ShouldReturnStatistic()
        {
            //Arrange

            //Act
            var doctor = await doctorService.GetDoctorByIdAsync("2");
            var statistic = await doctorService.GetDoctorStatisticsAsync(doctor);

            //Assert
            Assert.That(statistic.Rating, Is.EqualTo(4));
        }

        [Test]
        public async Task GetAllDoctorExaminationAsync_ReturnDoctorExaminations()
        {
            //Arrange

            //Act
            var examination = await doctorService.GetAllDoctorExaminationAsync("1");
            var examinationIdDate = await doctorService.GetAllDoctorExaminationAsync("1", "05.01.2023");
            var examinationNot = await doctorService.GetAllDoctorExaminationAsync("1", "08.01.2023");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(examination.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(examinationIdDate.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(examinationNot.TotalExaminationCount, Is.EqualTo(0));
            });
        }
    }
}
