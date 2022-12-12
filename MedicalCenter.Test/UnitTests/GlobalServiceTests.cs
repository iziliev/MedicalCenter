using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;

namespace MedicalCenter.Test.UnitTests
{
    [TestFixture]
    public class GlobalServiceTests : UnitTestBase
    {
        private IGlobalService globalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            globalService = new GlobalService(userManagerMock, data,dateTimeService);
        }

        [Test]
        public void ParsePnoneNumber_ReturnPhoneNumber()
        {
            //Act

            var phone1 = "0885065945";
            var phone2 = "+359886455698";

            //Arrange

            var parse1 = globalService.ParsePnoneNumber(phone1);
            var parse2 = globalService.ParsePnoneNumber(phone2);

            //Assert

            Assert.IsNotNull(parse1);
            Assert.IsNotNull(parse2);
            Assert.IsTrue(parse1.Equals("+359885065945"));
            Assert.IsTrue(parse2.Equals("+359886455698"));
        }

        [Test]
        public async Task GetSpecialties_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var specialities = await globalService.GetSpecialtiesAsync();

            //Assert
            Assert.IsNotNull(specialities);
            Assert.AreEqual(specialities.Count(), 3);
        }

        [Test]
        public async Task GetGenders_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var genders = await globalService.GetGendersAsync();

            //Assert
            Assert.IsNotNull(genders);
            Assert.AreEqual(genders.Count(), 3);
            Assert.AreEqual(genders.First().Name, "M");
        }

        [Test]
        public async Task GetShedule_ShouldReturnAllShedule()
        {
            //Arrange

            //Act
            var shedules = await globalService.GetShedulesAsync();
            //Assert
            Assert.IsNotNull(shedules);
            Assert.AreEqual(shedules.Count(), 2);
        }

        [Test]
        public void ReturnCorrectDateToString()
        {
            //Arrange

            //Act
            var date=globalService.ReturnDateToString();
            var dateToString = DateTime.Now.ToString("dd.MM.yyyy");

            //Assert
            Assert.AreEqual(date, dateToString);
        }
    }
}
