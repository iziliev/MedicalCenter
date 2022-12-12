using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Areas.Administrator.Services;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class AdministratorServiceTests : UnitTestBase
    {
        private IAdministratorService administratorService;
        private IGlobalService globalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            globalService = new GlobalService(userManagerMock, data, dateTimeService);
            administratorService = new AdministratorService(userManagerMock, data, globalService, null, dateTimeService);
        }

        [Test]
        public async Task GetUserByEgn_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var resultAdminExist = await administratorService.GetByEgnAsync<Administrator>("1111111111");
            var resultAdminNotExist = await administratorService.GetByEgnAsync<Administrator>("0000000000");

            //Assert a correct id is returned
            Assert.Multiple(() =>
            {
                Assert.That(resultAdminExist, Is.Not.Null);
                Assert.That(resultAdminExist.User.Role, Is.EqualTo("Administrator"));
                Assert.That(resultAdminExist.Id, Is.EqualTo("1"));
                Assert.That(resultAdminExist.UserId, Is.EqualTo("1"));
                Assert.That(resultAdminNotExist, Is.Null);
            });
        }

        [Test]
        public async Task SearchUserByEgn_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with not valid egn
            var resultAdminNotExist = await administratorService.SearchUserByEgnAsync<CreateAdminViewModel, Administrator>("5555");
            var resultDoctorNotExist = await administratorService.SearchUserByEgnAsync<CreateDoctorViewModel, Doctor>("5555");
            var resultLaborantNotExist = await administratorService.SearchUserByEgnAsync<CreateLaborantViewModel, Laborant>("5555");

            //Act: invoke the service method with valid egn
            var resultAdminExist = await administratorService.SearchUserByEgnAsync<CreateAdminViewModel, Administrator>("1111111111");
            var resultDoctorExist = await administratorService.SearchUserByEgnAsync<CreateDoctorViewModel, Doctor>("3333333333");
            var resultLaborantExist = await administratorService.SearchUserByEgnAsync<CreateLaborantViewModel, Laborant>("4444444444");

            //Assert a correct id is returned

            Assert.Multiple(() =>
            {
                Assert.That(resultAdminNotExist, Is.Null);
                Assert.That(resultAdminExist, Is.Not.Null);
                Assert.That(resultDoctorNotExist, Is.Null);
                Assert.That(resultDoctorExist, Is.Not.Null);
                Assert.That(resultLaborantNotExist, Is.Null);
                Assert.That(resultLaborantExist, Is.Not.Null);
            });
        }

        [Test]
        public async Task GetUserById_ShouldReturnCorrectUser()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var doctor = await administratorService.GetUserByIdAsync<Doctor>("2");
            var admin = await administratorService.GetUserByIdAsync<Administrator>("1");
            var laborant = await administratorService.GetUserByIdAsync<Laborant>("1");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(doctor, Is.Not.Null);
                Assert.That(doctor.Egn, Is.EqualTo("3333333333"));
                Assert.That(admin, Is.Not.Null);
                Assert.That(admin.Egn, Is.EqualTo("1111111111"));
                Assert.That(laborant, Is.Not.Null);
                Assert.That(laborant.Egn, Is.EqualTo("4444444444"));
            });
        }

        [Test]
        public async Task GetSpecialties_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var specialities = await administratorService.GetSpecialtiesAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(specialities, Is.Not.Null);
                Assert.That(specialities.Count(), Is.EqualTo(3));
            });
        }

        [Test]
        public async Task GetGenders_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var genders = await administratorService.GetGendersAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(genders, Is.Not.Null);
                Assert.That(genders.Count(), Is.EqualTo(3));
                Assert.That(genders.First().Name, Is.EqualTo("M"));
            });
        }

        [Test]
        public async Task GetShedule_ShouldReturnAllShedule()
        {
            //Arrange
            //Act
            var shedules = await administratorService.GetShedulesAsync();

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(shedules, Is.Not.Null);
                Assert.That(shedules.Count(), Is.EqualTo(2));
                Assert.That(shedules.First().Name, Is.EqualTo("1"));
                Assert.That(shedules.First().Doctors.First().User.FirstName, Is.EqualTo("Doctor1"));
            });
        }

        [Test]
        public async Task GetUserByIdToEditAsync_ShouldReturnCorrectType()
        {
            //Arrange
            var doctorId = "2";
            var adminId = "1";
            var laborantId = "1";

            //Act
            var doctor = await administratorService.GetUserByIdToEditAsync<MainDoctorViewModel, Doctor>(doctorId);
            var admin = await administratorService.GetUserByIdToEditAsync<MainAdminViewModel, Administrator>(adminId);
            var laborant = await administratorService.GetUserByIdToEditAsync<MainLaborantViewModel, Laborant>(laborantId);

            //Assert 
            Assert.Multiple(() =>
            {
                Assert.That(doctor, Is.Not.Null);
                Assert.That(admin, Is.Not.Null);
                Assert.That(laborant, Is.Not.Null);
            });
        }

        [Test]
        public async Task EditUser_ShouldReturnEditedInfoForUser()
        {
            //Arrange
            var doctorId = "2";
            var adminId = "1";
            var laborantId = "1";

            //Act
            var doctor = await administratorService.GetUserByIdAsync<Doctor>(doctorId);
            var doctorModel = new MainDoctorViewModel()
            {
                Email = doctor.User.Email,
                Education = doctor.Education,
                PhoneNumber = doctor.User.PhoneNumber,
                LastName = doctor.User.LastName,
                Biography = doctor.Biography,
                FirstName = "Doctor1Edit",
                Gender = doctor.User.GenderId,
                Id = doctor.Id,
                JoinOnDate = doctor.User.JoinOnDate,
                Role = doctor.User.Role,
                ProfileImageUrl = doctor.ProfileImageUrl,
                SpecialtyId = doctor.SpecialtyId,
                Representation = doctor.Representation,
                Username = doctor.User.UserName,
                OutOnDate = doctor.OutOnDate,
                SheduleId = doctor.SheduleId
            };
            await administratorService.EditUserAsync<MainDoctorViewModel, Doctor>(doctorModel, doctor);
            doctor = await administratorService.GetUserByIdAsync<Doctor>(doctorId);

            var admin = await administratorService.GetUserByIdAsync<Administrator>(adminId);
            var adminModel = new MainAdminViewModel()
            {
                Email = admin.User.Email,
                PhoneNumber = admin.User.PhoneNumber,
                LastName = admin.User.LastName,
                FirstName = "AdminEdit",
                Gender = admin.User.GenderId,
                Id = admin.Id,
                JoinOnDate = admin.User.JoinOnDate,
                Role = admin.User.Role,
                Username = admin.User.UserName,
                OutOnDate = admin.OutOnDate,
            };
            await administratorService.EditUserAsync<MainAdminViewModel, Administrator>(adminModel, admin);
            admin = await administratorService.GetUserByIdAsync<Administrator>(adminId);

            var laborant = await administratorService.GetUserByIdAsync<Laborant>(laborantId);
            var laborantModel = new MainLaborantViewModel()
            {
                Email = laborant.User.Email,
                PhoneNumber = laborant.User.PhoneNumber,
                LastName = laborant.User.LastName,
                FirstName = "LaborantEdit",
                Gender = laborant.User.GenderId,
                Id = laborant.Id,
                JoinOnDate = laborant.User.JoinOnDate,
                Role = laborant.User.Role,
                Username = laborant.User.UserName,
                OutOnDate = laborant.OutOnDate,
            };
            await administratorService.EditUserAsync<MainLaborantViewModel, Laborant>(laborantModel, laborant);
            laborant = await administratorService.GetUserByIdAsync<Laborant>(laborantId);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(doctor.User.FirstName, Is.EqualTo("Doctor1Edit"));
                Assert.That(admin.User.FirstName, Is.EqualTo("AdminEdit"));
                Assert.That(laborant.User.FirstName, Is.EqualTo("LaborantEdit"));
            });

        }

        [Test]
        public async Task DeleteAndReturnUser_ShouldDeleteAndReturnUser()
        {
            //Arrange
            var doctorId = "2";

            //Act

            await administratorService.DeleteAsync<Doctor>(doctorId);

            var doctors = await administratorService.GetAllCurrentDoctorsAsync(null, null, null, 1, 6);
            var leftDoctors = await administratorService.GetAllLeftDoctorsAsync(null, null, null, 1, 6);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(doctors.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(leftDoctors.TotalDoctorsCount, Is.EqualTo(1));
            });

            //Act
            await administratorService.ReturnAsync<Doctor>(doctorId);
            doctors = await administratorService.GetAllCurrentDoctorsAsync(null, null, null, 1, 6);
            leftDoctors = await administratorService.GetAllLeftDoctorsAsync(null, null, null, 1, 6);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(doctors.TotalDoctorsCount, Is.EqualTo(2));
                Assert.That(leftDoctors.TotalDoctorsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetStatistic_ShouldReturnStatistic()
        {
            //Arrange

            //Act

            var modelData = await administratorService.GetStatisticsAsync<DashboardStatisticDataViewModel>();
            var modelLab = await administratorService.GetStatisticsAsync<DashboardStatisticLabViewModel>();
            var modelAdmin = await administratorService.GetStatisticsAsync<DashboardStatisticAdminViewModel>();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(modelData.CountRaings, Is.EqualTo(1));
                Assert.That(modelLab.AllLaborantCount, Is.EqualTo(1));
                Assert.That(modelAdmin.AllAdministratorCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetCurrentAdminAsync_ShouldReturnAllCurrentAdmin()
        {
            //Arrange

            //Act
            var adminsWithId = await administratorService.GetAllCurrentAdminAsync("5");
            var adminsWithIdAndEgn = await administratorService.GetAllCurrentAdminAsync("5", "1111111111");
            var adminsWithIdEgnAndName = await administratorService.GetAllCurrentAdminAsync("5", "1111111111", "Admin");

            //Arrange
            Assert.Multiple(() =>
            {
                Assert.That(adminsWithId.TotalAdminsCount, Is.EqualTo(1));
                Assert.That(adminsWithIdAndEgn.TotalAdminsCount, Is.EqualTo(1));
                Assert.That(adminsWithIdEgnAndName.TotalAdminsCount, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetLeftAdminAsync_ShouldReturnAllLeftAdmin()
        {
            //Arrange
            var adminId = "1";
            await administratorService.DeleteAsync<Administrator>(adminId);

            //Act
            var admins = await administratorService.GetAllLeftAdminAsync();
            var adminEgn = await administratorService.GetAllLeftAdminAsync("1111111111");
            var adminEgnName = await administratorService.GetAllLeftAdminAsync("1111111111", "Admin");

            var adminNotExist = await administratorService.GetAllLeftAdminAsync("A", "2222222222");

            await administratorService.ReturnAsync<Administrator>(adminId);
            var adminAll = await administratorService.GetAllCurrentAdminAsync(adminId);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(admins.TotalAdminsCount, Is.EqualTo(1));
                Assert.That(adminEgn.TotalAdminsCount, Is.EqualTo(1));
                Assert.That(adminEgnName.TotalAdminsCount, Is.EqualTo(1));
                Assert.That(adminNotExist.TotalAdminsCount, Is.EqualTo(0));
                Assert.That(adminAll.TotalAdminsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task CreateUserAsync_ShouldCreateUser()
        {
            //Arrange

            var doctorModel = new CreateDoctorViewModel
            {
                Biography = "R",
                Education = "P",
                Egn = "1001111111",
                Email = "doctor3@mail.bg",
                FirstName = "Doctor3",
                LastName = "Doctorov3",
                Username = "doctor3",
                Gender = 1,
                JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy"),
                Password = "Doctor1!",
                PhoneNumber = "+359885464646",
                ProfileImageUrl = "https://rrrr.com",
                Representation = "REEEE",
                Role = "Doctor",
                SheduleId = 1,
                SpecialtyId = 1
            };

            var admin = new CreateAdminViewModel()
            {
                Egn = "9897949596",
                Email = "admin1@mail.bg",
                FirstName = "Admin1",
                LastName = "Adminov1",
                Gender = 1,
                Password = "Admin1!",
                PhoneNumber = "0887454546",
                Username = "admin1",
            };

            var laborant = new CreateLaborantViewModel()
            {
                Egn = "9897949596",
                Email = "laborant1@mail.bg",
                FirstName = "Laborant1",
                LastName = "Laborantov1",
                Gender = 3,
                Password = "Laborant1!",
                PhoneNumber = "0887454535",
                Username = "laborant_1",
            };

            //Act
            var createDoctorResult = await administratorService.CreateUserAsync(doctorModel);
            var createAdminResult = await administratorService.CreateUserAsync(admin);
            var createLaborantResult = await administratorService.CreateUserAsync(laborant);

            //Assert
            Assert.That(createDoctorResult.Succeeded, Is.True);
            Assert.IsTrue(createAdminResult.Succeeded);
            Assert.IsTrue(createLaborantResult.Succeeded);
        }

        [Test]
        public async Task DeleteAndReturnUserAsync_ShouldDeleteAndReturnUser()
        {
            //Arrange
            var laborant = await administratorService.GetByEgnAsync<Laborant>("4444444444");
            var laborantOutCompanyBegoreDelete = laborant.User.IsOutOfCompany;

            var admin = await administratorService.GetByEgnAsync<Administrator>("1111111111");
            var adminOutCompanyBegoreDelete = admin.User.IsOutOfCompany;

            var doctor = await administratorService.GetByEgnAsync<Doctor>("2222222222");
            var doctorOutCompanyBegoreDelete = doctor.User.IsOutOfCompany;

            //Act
            await administratorService.DeleteAsync<Laborant>(laborant.Id);
            var laborantOutCompanyAfterDelete = laborant.User.IsOutOfCompany;
            await administratorService.ReturnAsync<Laborant>(laborant.Id);
            var laborantOutCompanyAfterReturn = laborant.User.IsOutOfCompany;

            await administratorService.DeleteAsync<Administrator>(admin.Id);
            var adminOutCompanyAfterDelete = admin.User.IsOutOfCompany;
            await administratorService.ReturnAsync<Administrator>(admin.Id);
            var adminOutCompanyAfterReturn = admin.User.IsOutOfCompany;

            await administratorService.DeleteAsync<Doctor>(doctor.Id);
            var doctorOutCompanyAfterDelete = doctor.User.IsOutOfCompany;
            await administratorService.ReturnAsync<Doctor>(doctor.Id);
            var doctorOutCompanyAfterReturn = doctor.User.IsOutOfCompany;

            //Assert
            Assert.IsFalse(laborantOutCompanyBegoreDelete);
            Assert.IsTrue(laborantOutCompanyAfterDelete);
            Assert.IsFalse(laborantOutCompanyAfterReturn);

            Assert.IsFalse(adminOutCompanyBegoreDelete);
            Assert.IsTrue(adminOutCompanyAfterDelete);
            Assert.IsFalse(adminOutCompanyAfterReturn);

            Assert.IsFalse(doctorOutCompanyBegoreDelete);
            Assert.IsTrue(doctorOutCompanyAfterDelete);
            Assert.IsFalse(doctorOutCompanyAfterReturn);
        }

        [Test]
        public async Task FillGendersSpecialitiesSheduleInEditViewAsyanc_ShouldFillGendersSpecialitiesSheduleInEditView()
        {
            //Arrange
            var doctorId = "1";

            //Act
            var editDoctorModel = await administratorService.GetUserByIdToEditAsync<MainDoctorViewModel, Doctor>(doctorId);

            var model = await administratorService.FillGendersSpecialitiesSheduleInEditViewAsyanc(editDoctorModel);


            //Assert
            Assert.IsNotNull(model.Genders);
            Assert.IsNotNull(model.Specialties);
            Assert.IsNotNull(model.Shedules);
        }

        [Test]
        public async Task FillGendersSpecialitiesSheduleInCreateViewAsyanc_ShouldFillFillGendersSpecialitiesSheduleInCreateView()
        {
            //Arrange
            var createModel = new CreateDoctorViewModel();

            //Act
            var model = await administratorService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(createModel);

            //Assert
            Assert.IsNotNull(model.Genders);
            Assert.IsNotNull(model.Specialties);
            Assert.IsNotNull(model.Shedules);
        }

        [Test]
        public async Task GetAllPastExamination_ShouldReturnAllNotCanceledPastExamination()
        {
            //Arrange

            //Act
            var pastExam = await administratorService.GetAllPastExamination();
            var pastExamSpec = await administratorService.GetAllPastExamination("A");
            var pastExamSpecDate = await administratorService.GetAllPastExamination("A", "02.11.2022");
            var pastExamSpecDateName = await administratorService.GetAllPastExamination("A", "02.11.2022", "Doctor1");

            var pastExamNotExist = await administratorService.GetAllPastExamination("R", "02.11.2022", "Doctor1");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(pastExam.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(pastExamSpec.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(pastExamSpecDate.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(pastExamSpecDateName.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(pastExamNotExist.TotalExaminationCount, Is.EqualTo(0));
            });


        }
        [Test]
        public async Task GetAllFutureExamination_ShouldReturnAllNotCanceledFutureExamination()
        {
            //Arrange

            //Act
            var futureExam = await administratorService.GetAllFutureExamination();
            var futureExamSpec = await administratorService.GetAllFutureExamination("A");
            var futureExamSpecDate = await administratorService.GetAllFutureExamination("A", "05.01.2023");
            var futureExamSpecName = await administratorService.GetAllFutureExamination("A", "05.01.2023", "Doctor1");

            var notExistExam = await administratorService.GetAllFutureExamination("K");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(futureExam.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(futureExamSpec.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(futureExamSpecDate.TotalExaminationCount, Is.EqualTo(1));
                Assert.That(futureExamSpecName.TotalExaminationCount, Is.EqualTo(1));

                Assert.That(notExistExam.TotalExaminationCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetAllCurrentDoctor_ShouldReturnAllCurrentDoctor()
        {
            //Arrange

            //Act
            var doctors = await administratorService.GetAllCurrentDoctorsAsync();
            var doctorsWithSpec = await administratorService.GetAllCurrentDoctorsAsync("A");
            var doctorWithSpecAndEgn = await administratorService.GetAllCurrentDoctorsAsync("A", "2222222222");
            var doctorWithSpecAndEgnName = await administratorService.GetAllCurrentDoctorsAsync("A", "2222222222", "Doctor1");

            var doctorNotExist = await administratorService.GetAllCurrentDoctorsAsync("A", "5555", "Doctor1");

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(doctors.TotalDoctorsCount, Is.EqualTo(2));
                Assert.That(doctorsWithSpec.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorWithSpecAndEgn.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorWithSpecAndEgnName.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorNotExist.TotalDoctorsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetAllLeftDoctor_ShouldReturnAllLeftDoctor()
        {
            //Arrange
            var doctorId = "1";
            await administratorService.DeleteAsync<Doctor>(doctorId);

            //Act
            var doctors = await administratorService.GetAllLeftDoctorsAsync();
            var doctorsSpec = await administratorService.GetAllLeftDoctorsAsync("A");
            var doctorsSpecEgn = await administratorService.GetAllLeftDoctorsAsync("A", "2222222222");
            var doctorsSpecEgnName = await administratorService.GetAllLeftDoctorsAsync("A", "2222222222", "Doctor1");

            var doctorsNotExist = await administratorService.GetAllLeftDoctorsAsync("A", "2222222222", "Doctor15");

            await administratorService.ReturnAsync<Doctor>(doctorId);
            var doctorsAll = await administratorService.GetAllCurrentDoctorsAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(doctors.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorsSpec.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorsSpecEgn.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorsSpecEgnName.TotalDoctorsCount, Is.EqualTo(1));
                Assert.That(doctorsNotExist.TotalDoctorsCount, Is.EqualTo(0));
                Assert.That(doctorsAll.TotalDoctorsCount, Is.EqualTo(2));
            });
        }

        [Test]
        public async Task GetAllCurrentLaborant_ShouldReturnAllCurrentLaborant()
        {
            //Arrange

            //Act
            var laborants = await administratorService.GetAllCurrentLaborantsAsync();
            var laborantsEgn = await administratorService.GetAllCurrentLaborantsAsync("4444444444");
            var laborantsEgnName = await administratorService.GetAllCurrentLaborantsAsync("4444444444", "Laborant");

            var laborantsNotExist = await administratorService.GetAllCurrentLaborantsAsync("5555", "Laborant");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(laborants.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(laborantsEgn.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(laborantsEgnName.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(laborantsNotExist.TotalLaborantsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetAllLeftLaborants_ShouldReturnAllLeftLaborants()
        {
            //Arrange
            var laborantId = "1";
            await administratorService.DeleteAsync<Laborant>(laborantId);

            //Act
            var leftlaborants = await administratorService.GetAllLeftLaborantsAsync();
            var leftlaborantsEgn = await administratorService.GetAllLeftLaborantsAsync("4444444444");
            var leftlaborantsEgnName = await administratorService.GetAllLeftLaborantsAsync("4444444444", "Laborant");

            var leftlaborantsNotExist = await administratorService.GetAllLeftLaborantsAsync("55555");

            await administratorService.ReturnAsync<Laborant>(laborantId);
            var leftlaborantsAll = await administratorService.GetAllLeftLaborantsAsync();

            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(leftlaborants.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(leftlaborantsEgn.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(leftlaborantsEgnName.TotalLaborantsCount, Is.EqualTo(1));
                Assert.That(leftlaborantsNotExist.TotalLaborantsCount, Is.EqualTo(0));
                Assert.That(leftlaborantsAll.TotalLaborantsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task GetAllRegisteredUsersAsync_ShouldReturnAllRegisteredUser()
        {
            //Arrange

            //Act
            var users = await administratorService.GetAllRegisteredUsersAsync();
            var usersWithEmail = await administratorService.GetAllRegisteredUsersAsync("user1@mail.bg");
            var usersWithEmailAndName = await administratorService.GetAllRegisteredUsersAsync("user1@mail.bg", "User1");

            var usersnotExist = await administratorService.GetAllRegisteredUsersAsync("User10");
            //Assrt

            Assert.Multiple(() =>
            {
                Assert.That(users.TotalUsersCount, Is.EqualTo(2));
                Assert.That(usersWithEmail.TotalUsersCount, Is.EqualTo(1));
                Assert.That(usersWithEmailAndName.TotalUsersCount, Is.EqualTo(1));
                Assert.That(usersnotExist.TotalUsersCount, Is.EqualTo(0));
            });
        }
    }
}
