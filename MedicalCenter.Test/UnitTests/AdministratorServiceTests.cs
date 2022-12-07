using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Areas.Administrator.Services;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class AdministratorServiceTests : UnitTestBase
    {
        private IAdministratorService administratorService;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            administratorService = new AdministratorService(null, data, null, null,dateTimeService);
        }

        [Test]
        public async Task GetUserByEgn_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var resultAdminExist = await administratorService.GetByEgnAsync<Administrator>("1111111111");
            var resultAdminNotExist = await administratorService.GetByEgnAsync<Administrator>("9999999999");

            //Assert a correct id is returned
            Assert.IsNotNull(resultAdminExist);
            Assert.AreEqual(resultAdminExist.User.Role, "Administrator");
            Assert.AreEqual(resultAdminExist.Id, "1");
            Assert.AreEqual(resultAdminExist.UserId, "1");
            Assert.IsNull(resultAdminNotExist);
        }

        [Test]
        public async Task SearchUserByEgn_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with not valid egn
            var resultAdminNotExist = await administratorService.SearchUserByEgnAsync<CreateAdminViewModel, Administrator>("5555");

            //Act: invoke the service method with valid egn
            var resultAdminExist = await administratorService.SearchUserByEgnAsync<CreateAdminViewModel, Administrator>("1111111111");

            //Assert a correct id is returned
            Assert.IsNull(resultAdminNotExist);
            Assert.IsNotNull(resultAdminExist);
        }

        [Test]
        public async Task GetUserById_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var doctor = await administratorService.GetUserByIdAsync<Doctor>("2");

            //Assert
            Assert.IsNotNull(doctor);
            Assert.AreEqual(doctor.Egn, "3333333333");
        }

        [Test]
        public async Task GetSpecialties_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var specialities = await administratorService.GetSpecialtiesAsync();

            //Assert
            Assert.IsNotNull(specialities);
            Assert.AreEqual(specialities.Count(), 3);
        }

        [Test]
        public async Task GetGenders_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var genders = await administratorService.GetGendersAsync();

            //Assert
            Assert.IsNotNull(genders);
            Assert.AreEqual(genders.Count(), 3);
            Assert.AreEqual(genders.First().Name, "M");
        }

        [Test]
        public async Task GetShedule_ShouldReturnAllShedule()
        {
            //Arrange
            var doctorId = "6";

            //Act
            var shedules = await administratorService.GetShedulesAsync();
            var doctor = await administratorService.GetUserByIdAsync<Doctor>(doctorId);
            //Assert
            Assert.IsNotNull(shedules);
            Assert.AreEqual(shedules.Count(), 2);
            Assert.AreEqual(shedules.First().Name, "1");
            Assert.AreEqual(shedules.First().Doctors.First().User.FirstName, "Doctor1");
        }

        [Test]
        public async Task GetUserByIdToEditAsync_ShouldReturnCorrectType()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var doctor = await administratorService.GetUserByIdToEditAsync<MainDoctorViewModel, Doctor>(doctorId);

            //Assert 
            Assert.IsNotNull(doctor);
        }

        [Test]
        public async Task EditUser_ShouldReturnEditedInfoForUser()
        {
            //Arrange
            var doctorId = "1";
            
            //Act
            var doctor = await administratorService.GetUserByIdToEditAsync<MainDoctorViewModel, Doctor>(doctorId);
            doctor.FirstName = "Doctor1Edit";
            await data.SaveChangesAsync();

            //Assert
            Assert.AreEqual(doctor.FirstName, "Doctor1Edit");
        }

        [Test]
        public async Task DeleteAndReturnUser_ShouldDeleteAndReturnUser()
        {
            //Arrange
            var doctorId = "2";

            //Act

            await administratorService.DeleteAsync<Doctor>(doctorId);

            var doctors = await administratorService.GetAllCurrentDoctorsAsync(null,null,null,1,6);
            var leftDoctors = await administratorService.GetAllLeftDoctorsAsync(null,null,null,1,6);

            //Assert
            Assert.AreEqual(doctors.TotalDoctorsCount, 1);
            Assert.AreEqual(leftDoctors.TotalDoctorsCount, 1);

            await administratorService.ReturnAsync<Doctor>(doctorId);

            doctors = await administratorService.GetAllCurrentDoctorsAsync(null, null, null, 1, 6);
            leftDoctors = await administratorService.GetAllLeftDoctorsAsync(null, null, null, 1, 6);

            //Assert
            Assert.AreEqual(doctors.TotalDoctorsCount, 2);
            Assert.AreEqual(leftDoctors.TotalDoctorsCount, 0);
        }

        [Test]
        public async Task GetStatistic_ShouldReturnStatistic()
        {
            //Arrange

            //Act
            
            var model = await administratorService.GetStatisticsAsync<DashboardStatisticDataViewModel>();

            //Assert
            Assert.AreEqual(model.CountRaings, 1);
        }

        [Test]
        public async Task GetCurrentAdminAsync_ShouldReturnAllCurrentAdmin()
        {
            //Arrange

            //Act
            var admins = await administratorService.GetAllCurrentAdminAsync("5");

            //Arrange
            Assert.AreEqual(admins.TotalAdminsCount, 1);
        }

        [Test]
        public async Task GetLeftAdminAsync_ShouldReturnAllLeftAdmin()
        {
            //Arrange

            //Act
            var leftAdmins = await administratorService.GetAllLeftAdminAsync();

            //Arrange
            Assert.AreEqual(leftAdmins.TotalAdminsCount, 0);
        }

        //[Test]
        //public async Task CreateUserAsync_ShouldCreateUser()
        //{
        //    //Arrange

        //    var doctorModel = new CreateDoctorViewModel
        //    {
        //        Biography = "R",
        //        Education = "P",
        //        Egn = "1001111111",
        //        Email = "doctor3@mail.bg",
        //        FirstName = "Doctor3",
        //        LastName = "Doctorov3",
        //        Username = "doctor3",
        //        Gender = 1,
        //        JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy"),
        //        Password = "Doctor",
        //        PhoneNumber = "+359885464646",
        //        ProfileImageUrl = "https://rrrr.com",
        //        Representation = "REEEE",
        //        Role = "Doctor",
        //        SheduleId = 1,
        //        SpecialtyId = 1
        //    };

        //    //Act

        //    await administratorService.CreateUserAsync(doctorModel);

        //    var doctor = await administratorService.GetByEgnAsync<Doctor>("1001111111");

        //    //Assert

        //    Assert.NotNull(doctor);
        //    Assert.AreEqual(doctor.Biography, "R");
        //}

        //[Test]
        //public async Task CreateAdmin()
        //{;
        //    var admin = new CreateAdminViewModel()
        //    {
        //        Egn = "9897949596",
        //        Email = "admin1@mail.bg",
        //        FirstName = "Admin1",
        //        LastName = "Adminov1",
        //        Gender = 1,
        //        Password = "Admin1!",
        //        PhoneNumber = "0887454546",
        //        Username = "admin1",
        //    };

        //    await administratorService.CreateUserAsync(admin);

        //    var admins = await administratorService.GetAllCurrentAdminAsync("1");

        //    Assert.AreEqual(admins.TotalAdminsCount, 1);

        //}
    }
}
