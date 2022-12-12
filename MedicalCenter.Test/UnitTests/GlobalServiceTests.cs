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

            Assert.Multiple(() =>
            {
                Assert.That(parse1, Is.Not.Null);
                Assert.That(parse2, Is.Not.Null);
                Assert.That(parse1, Is.EqualTo("+359885065945"));
                Assert.That(parse2, Is.EqualTo("+359886455698"));
            });
        }

        [Test]
        public async Task GetSpecialties_ShouldReturnAllSpecialities()
        {
            //Arrange

            //Act
            var specialities = await globalService.GetSpecialtiesAsync();

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
            var genders = await globalService.GetGendersAsync();

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
            var shedules = await globalService.GetShedulesAsync();
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(shedules, Is.Not.Null);
                Assert.That(shedules.Count(), Is.EqualTo(2));
            });
        }

        [Test]
        public void ReturnCorrectDateToString()
        {
            //Arrange

            //Act
            var date=globalService.ReturnDateToString();
            var dateToString = DateTime.Now.ToString("dd.MM.yyyy");

            //Assert
            Assert.That(date, Is.EqualTo(dateToString));
        }
    }
}
