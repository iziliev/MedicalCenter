using MedicalCenter.Areas.Administrator.Services;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class AdministratorServiceTests : UnitTestBase
    {
        private IAdministratorService administratorService;

        [OneTimeSetUp]
        public async Task SetUp()
            =>this.administratorService = new AdministratorService(null,this.data,null,null);

        [Test]
        public async Task GetAdminId_ShouldReturnCorrectUserId()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var resultAdmin = await administratorService.GetByEgnAsync<Administrator>("1111111111");

            //Assert a correct id is returned
            Assert.AreEqual(resultAdmin.User.Role,"Administrator");
            Assert.AreEqual(resultAdmin.Id, "5");
            Assert.AreEqual(resultAdmin.UserId, "1");
        }

        [Test]
        public async Task GetDoctorId_ShouldReturnCorrectUserId()
        {
            //Arrange

            //Act: invoke the service method with valid id
            var resultDoctor = await administratorService.GetByEgnAsync<Doctor>("3333333333");

            administratorService.

            //Assert a correct id is returned
            Assert.AreEqual(resultDoctor.User.Role, "Doctor");
            Assert.AreEqual(resultDoctor.Biography, "D");
            Assert.AreEqual(resultDoctor.Id, "7");
            Assert.AreEqual(resultDoctor.UserId, "3");
        }
    }
}
