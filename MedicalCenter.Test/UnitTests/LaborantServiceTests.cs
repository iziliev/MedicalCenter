using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Laborant;
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
    public class LaborantServiceTests : UnitTestBase
    {
        private ILaborantService laborantService;
        private IGlobalService globalService;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            globalService = new GlobalService(null,data);
            laborantService = new LaborantService(globalService,null,data);
        }

        [Test]
        public async Task SearchLaboratoryPatientByEgnAsync_ShouldReturnLaboratoryPatient()
        {
            //Arrange

            //Act
            var patient = await laborantService.GetLaboratoryPatientByEgnAsync("8989898989");

            //Assert
            Assert.IsNotNull(patient);
            Assert.AreEqual(patient.User.FirstName, "Patient");
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
    }
}
