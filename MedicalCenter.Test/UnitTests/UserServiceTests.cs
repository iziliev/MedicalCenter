using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestBase
    {
        private IUserService userService;
        private IGlobalService globalService;
        [OneTimeSetUp]
        public async Task SetUp()
        {
            globalService = new GlobalService(null, data);
            userService = new UserService(null, null, data, null);


        }

        [Test]
        public async Task IsUserEmailExistAsync_ShouldReturnBool()
        {
            //Arrange

            //Act
            var user = await userService.GetUserByUsernameAsync("user1");
            
            //Assert
            Assert.NotNull(user);
            Assert.AreEqual(user.Email, "user1@mail.bg");
        }

        [Test]
        public async Task ShowDoctorOnUserAsync_ShouldReturnAllDoctor()
        {
            //Arrange

            //Act
            var doctors = await userService.ShowDoctorOnUserAsync();

            var doctorsBySpeciality = await userService.ShowDoctorOnUserAsync(null,"Doctor1");

            //Assert
            Assert.NotNull(doctors);
            Assert.AreEqual(doctors.TotalDoctorsCount, 2);
            Assert.AreEqual(doctorsBySpeciality.TotalDoctorsCount, 1);
        }

        [Test]
        public async Task GetDoctorWorkHoursByDoctorIdAsync_ShouldReturnWorkDoctorHours()
        {
            //Arrange

            //Act
            var hours = await userService.GetDoctorWorkHoursByDoctorIdAsync("1");

            //Assert
            Assert.NotNull(hours);
            Assert.IsTrue(hours.Contains("08:00"));
            Assert.AreEqual(hours.Count(), 2);
        }

        [Test]
        public async Task GetDoctorByIdAsync_ShouldReturnDoctor()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var doctor = await userService.GetDoctorByIdAsync(doctorId);

            //Assert
            Assert.NotNull(doctor);
            Assert.AreEqual(doctor.User.FirstName, "Doctor1");
        }

        [Test]
        public async Task CreateExaminationAsync_ShouldCreateExaminatoion()
        {
            //Arrange
            var doctorId = "1";

            var user = await data.GetByIdAsync<User>("5");

            var doctor = await userService.GetDoctorByIdAsync(doctorId);

            var model = new BookExaminationViewModel()
            {
                Biography = doctor.Biography,
                Date = "22.12.2022",
                DoctorFullName = $"{doctor.User.FirstName} {doctor.User.LastName}",
                DoctorId = doctorId,
                Education = doctor.Education,
                Hour = "08:30",
                ProfileImage = "http://dddd",
                Representation = doctor.Representation,
                SpecialityName = "Akusher",
            };

            await userService.CreateExaminationAsync(user, doctor, model);

            var examinations = await userService.GetExaminationAsync(user.Id, model);

            var currExam = await userService.GetAllCurrentExaminationAsync(user.Id, null, "22.12.2022");

            //Assert
            Assert.NotNull(examinations);
            Assert.NotNull(currExam);
            Assert.AreEqual(examinations.Date, DateTime.Parse("22.12.2022"));
            Assert.AreEqual(currExam.TotalExaminationCount, 1);
        }

        [Test]
        public async Task ReturnDoctorNameByDoctorIdAsync_ShouldReturnDoctorName()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var doctorName = await userService.ReturnDoctorNameByDoctorIdAsync(doctorId);

            //Assert
            Assert.IsNotEmpty(doctorName);
            Assert.AreEqual(doctorName, "Doctor1 Doctorov1");
        }

        [Test]
        public async Task CancelUserExaminationAsync_ShouldCancelExaminatoion()
        {
            //Arrange
            var doctorId = "1";

            var user = new User() { Id = "158", Email = "user158@mail.bg", FirstName = "User158", LastName = "Userov158", GenderId = 1, JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy"), Role = "User", UserName = "user158", PhoneNumber = "+359666666" };

            await data.AddAsync(user);

            var doctor = await userService.GetDoctorByIdAsync(doctorId);

            var model = new BookExaminationViewModel()
            {
                Biography = doctor.Biography,
                Date = "22.12.2022",
                DoctorFullName = $"{doctor.User.FirstName} {doctor.User.LastName}",
                DoctorId = doctorId,
                Education = doctor.Education,
                Hour = "08:30",
                ProfileImage = "http://dddd",
                Representation = doctor.Representation,
                SpecialityName = "Akusher",
            };

            await userService.CreateExaminationAsync(user, doctor, model);

            var model1 = new BookExaminationViewModel()
            {
                Biography = doctor.Biography,
                Date = "22.12.2022",
                DoctorFullName = $"{doctor.User.FirstName} {doctor.User.LastName}",
                DoctorId = doctorId,
                Education = doctor.Education,
                Hour = "08:00",
                ProfileImage = "http://dddd",
                Representation = doctor.Representation,
                SpecialityName = "Akusher",
            };
            await userService.CreateExaminationAsync(user, doctor, model1);

            var model2 = new BookExaminationViewModel()
            {
                Biography = doctor.Biography,
                Date = "11.11.2022",
                DoctorFullName = $"{doctor.User.FirstName} {doctor.User.LastName}",
                DoctorId = doctorId,
                Education = doctor.Education,
                Hour = "08:30",
                ProfileImage = "http://dddd",
                Representation = doctor.Representation,
                SpecialityName = "Akusher",
            };

            await userService.CreateExaminationAsync(user, doctor, model2);

            var examinationOnDateBeforeCancel = await userService.GetAllCurrentExaminationAsync(user.Id, null, "22.12.2022");

            var examination = await userService.GetExaminationAsync(user.Id, model1);

            var examinationForRewiew = await userService.GetExaminationAsync(user.Id, model2);

            //Act

            await userService.CancelUserExaminationAsync(examination.Id);

            var examinationOnDateAfterCancel = await userService.GetAllCurrentExaminationAsync(user.Id, null, "22.12.2022");

            var examForReview = await userService.GetAllExaminationForReviewAsync(user.Id);

            //Assert
            Assert.AreEqual(examinationOnDateBeforeCancel.TotalExaminationCount,2);
            Assert.AreEqual(examinationOnDateAfterCancel.TotalExaminationCount, 1);
            Assert.AreEqual(examForReview.TotalExaminationsCount, 1);
        }
    }
}
