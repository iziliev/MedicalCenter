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
    public class LaboratoryPatientServiceTests:UnitTestBase
    {
        private ILaboratoryPatient laboratoryPatient;
        private IGlobalService globalService;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            globalService = new GlobalService(null, data);
            laboratoryPatient = new LaboratoryPatientService(null,null,data,globalService);
        }
        
        [Test]
        public async Task IsEgnExistAsync_ShouldReturbBool()
        {
            //Arrange
            //Act
            var isExist = await laboratoryPatient.IsEgnExistAsync("8989898989");
            var isNotExist = await laboratoryPatient.IsEgnExistAsync("8089898989");

            //Assert
            Assert.IsTrue(isExist);
            Assert.IsFalse(isNotExist);
        }

        [Test]
        public async Task IsUsernameExistAsync_ShouldReturbBool()
        {
            //Arrange
            //Act
            var isExist = await laboratoryPatient.IsUsernameExistAsync("pat_1");
            var isNotExist = await laboratoryPatient.IsUsernameExistAsync("pat_8089898989");

            //Assert
            Assert.IsTrue(isExist);
            Assert.IsFalse(isNotExist);
        }

        [Test]
        public async Task GetResultByIdAsync_ShouldReturnPatientResult()
        {
            //Arrange
            //Act
            var results = await laboratoryPatient.GetResultByIdAsync("1");

            //Assert
            Assert.NotNull(results);
            Assert.AreEqual(results.UrinepH, "1.5");
        }

        [Test]
        public async Task GetAllResult_ShouldReturnAllPatientResult()
        {
            //Arrange
            //Act
            var results = await laboratoryPatient.GetAllResult("7");

            //Assert
            Assert.NotNull(results);
            Assert.AreEqual(results.TotalResultCount, 1);
        }
    }
}
