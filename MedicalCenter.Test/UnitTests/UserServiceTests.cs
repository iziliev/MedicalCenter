using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestBase
    {
        private IUserService userService;
        private IGlobalService globalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            globalService = new GlobalService(usermanagerMock,data,dateTimeService);
            userService = new UserService(usermanagerMock, null, data, globalService);
        }
        
        [Test]
        public async Task GetUserByUsernameAsync_ShouldReturnBool()
        {
            //Arrange

            //Act
            var user = await userService.GetUserByUsernameAsync("user1");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null);
                Assert.That("user1@mail.bg", Is.EqualTo(user.Email));
            });
        }

        [Test]
        public async Task ShowDoctorOnUserAsync_ShouldReturnAllDoctor()
        {
            //Arrange

            //Act
            var doctors = await userService.ShowDoctorOnUserAsync();

            var doctorsBySpeciality = await userService.ShowDoctorOnUserAsync(null,"Doctor1");

            //Assert
            Assert.That(doctors, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(doctors.TotalDoctorsCount, Is.EqualTo(2));
                Assert.That(doctorsBySpeciality.TotalDoctorsCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetDoctorWorkHoursByDoctorIdAsync_ShouldReturnWorkDoctorHours()
        {
            //Arrange

            //Act
            var hours = await userService.GetDoctorWorkHoursByDoctorIdAsync("1");

            //Assert
            Assert.That(hours, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(hours.Contains("08:00"), Is.True);
                Assert.That(hours.Count(), Is.EqualTo(2));
            });
        }

        [Test]
        public async Task GetDoctorByIdAsync_ShouldReturnDoctor()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var doctor = await userService.GetDoctorByIdAsync(doctorId);

            //Assert
            Assert.That(doctor, Is.Not.Null);
            Assert.That(doctor.User.FirstName, Is.EqualTo("Doctor1"));
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
            Assert.Multiple(() =>
            {
                Assert.That(examinations, Is.Not.Null);
                Assert.That(currExam, Is.Not.Null);
                Assert.That(DateTime.Parse("22.12.2022"), Is.EqualTo(examinations.Date));
                Assert.That(currExam.TotalExaminationCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task ReturnDoctorNameByDoctorIdAsync_ShouldReturnDoctorName()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var doctorName = await userService.ReturnDoctorNameByDoctorIdAsync(doctorId);

            //Assert
            Assert.That(doctorName, Is.Not.Empty);
            Assert.That(doctorName, Is.EqualTo("Doctor1 Doctorov1"));
        }

        [Test]
        public async Task CancelUserExaminationAsync_ShouldCancelExaminatoion()
        {
            //Arrange
            var doctorId = "1";

            var user = new User() { Id = "158", Email = "user158@mail.bg", FirstName = "User158", LastName = "Userov158", GenderId = 1, JoinOnDate = globalService.ReturnDateToString(), Role = "User", UserName = "user158", PhoneNumber = "+359666666" };

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
            Assert.Multiple(() =>
            {
                Assert.That(examinationOnDateBeforeCancel.TotalExaminationCount, Is.EqualTo(2));
                Assert.That(examinationOnDateAfterCancel.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(examForReview.TotalExaminationsCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task RegisterUser_ShouldRegisterUser()
        {
            //Arrange
            var user = new RegisterViewModel
            {
                ConfirmPassword = "User84!",
                Email = "user5@mail.bg",
                FirstName = "User5",
                LastName = "Userov5",
                Gender = 1,
                Password = "User84!",
                PhoneNumber = "+359885659878",
                Username = "user5"
            };

            //Act
            var result = await userService.Register(user);

            //Assrt
            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.True);
            });
        }
    }
}