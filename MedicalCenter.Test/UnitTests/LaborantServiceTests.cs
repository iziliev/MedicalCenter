using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Laborant;
using MedicalCenter.Core.Services;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class LaborantServiceTests : UnitTestBase
    {
        private ILaborantService laborantService;
        private IGlobalService globalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            globalService = new GlobalService(userManagerMock, data,dateTimeService);
            laborantService = new LaborantService(globalService, userManagerMock, data);
        }

        [Test]
        public async Task SearchLaboratoryPatientByEgnAsync_ShouldReturnLaboratoryPatient()
        {
            //Arrange

            //Act
            var patient = await laborantService.SearchLaboratoryPatientByEgnAsync("8989898989");
            var patientNot = await laborantService.SearchLaboratoryPatientByEgnAsync("1289898989");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(patient, Is.Not.Null);
                Assert.That(patient.FirstName, Is.EqualTo("Patient"));
                Assert.That(patientNot, Is.Null);
            });
        }

        [Test]
        public async Task GetLaboratoryPatientByEgnAsync_ShouldReturnLaboratoryPatient()
        {
            //Arrange

            //Act
            var patient = await laborantService.GetLaboratoryPatientByEgnAsync("8989898989");

            //Assert
            Assert.IsNotNull(patient);
            Assert.AreEqual(patient.User.FirstName, "Patient");
        }

        [Test]
        public async Task GetAllCurrentLaboratoryPatientAsync_ShouldReturnAllLaboratoryPatients()
        {
            //Arrange

            //Act
            var patients = await laborantService.GetAllCurrentLaboratoryPatientAsync(null, null, 1, 6);

            //Assert
            Assert.IsNotNull(patients);
            Assert.AreEqual(patients.TotalLaboratoryPatientCount, 1);
        }

        [Test]
        public async Task UploadResultAsync_ShouldUploadTestToUser()
        {
            //Arrange
            var patient = await laborantService.GetLaboratoryPatientByEgnAsync("8989898989");
            var test = new UploadTestResultViewModel()
            {
                LaboratoryPatientId = patient.Id,
                Plt = "18.5",
                MCH = "28.5"
            };

            await laborantService.UploadResultAsync(test);

            var currentTest = patient.Tests.OrderByDescending(x=>x.TestDate).FirstOrDefault();

            //Assert
            Assert.AreEqual(patient.Tests.Count, 2);
            Assert.AreEqual(currentTest.Plt, "18.5");

        }

        [Test]
        public async Task CreateLaboratoryPatientAsync_ShouldCreateTestToUser()
        {
            //Arrange
            var model = new CreateLaboratoryPatientViewModel()
            {
                Egn = "1818181818",
                FirstName = "Patient123",
                Gender = 1,
                Id = "3",
                LastName = "Patientov123",
                Password = "Pat123!",
                PhoneNumber = "+359885457896",
                Role = "LaboratoryPatient",
                Username = "pat_1818181818"
            };

            //Act
            var result = await laborantService.CreateLaboratoryPatientAsync(model);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Succeeded, Is.True);
            });
        }

        [Test]
        public async Task GetAllCurrentLaboratoryPatientAsync_ReturnCurrentPatients()
        {
            //Arrange
            //Act

            var patients = await laborantService.GetAllCurrentLaboratoryPatientAsync();
            var patientsEgn = await laborantService.GetAllCurrentLaboratoryPatientAsync("8989898989");
            var patientsEgnName = await laborantService.GetAllCurrentLaboratoryPatientAsync("8989898989", "Patient");

            var patientsNotExist = await laborantService.GetAllCurrentLaboratoryPatientAsync("1111198989", "Patient");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(patients.TotalLaboratoryPatientCount, Is.EqualTo(1));
                Assert.That(patientsEgn.TotalLaboratoryPatientCount, Is.EqualTo(1));
                Assert.That(patientsEgnName.TotalLaboratoryPatientCount, Is.EqualTo(1));
                Assert.That(patientsNotExist.TotalLaboratoryPatientCount, Is.EqualTo(0));
            });
        }
    }
}
