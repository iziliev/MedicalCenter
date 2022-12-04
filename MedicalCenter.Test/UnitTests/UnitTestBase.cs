using MedicalCenter.Infrastructure.Data;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using MedicalCenter.Test.Mocks;

namespace MedicalCenter.Test.UnitTests
{
    public class UnitTestBase
    {
        protected IRepository data;

        [OneTimeSetUp]
        public async Task SetUpBase()
        {
            data = RepositoryMock.Instance;

            var users = new List<User>()
            {
                new User(){Id="1",Email="admin@mail.bg",FirstName="Admin",LastName="Adminov",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Administrator",UserName="admin"},
                new User(){Id="2",Email="doctor1@mail.bg",FirstName="Doctor1",LastName="Doctorov1",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Doctor",UserName="doctor1"},
                new User(){Id="3",Email="doctor2@mail.bg",FirstName="Doctor2",LastName="Doctorov2",GenderId=2,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Doctor",UserName="doctor2"},
                new User(){Id="4",Email="laborant@mail.bg",FirstName="Laborant",LastName="Laborantov",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Laborant",UserName="laborant"}
            };

            var admin = new Administrator()
            {
                Egn = "1111111111",
                Id = "5",
                User = users[0],
                UserId = users[0].Id
            };

            var doctors = new List<Doctor>()
            {
                new Doctor()
                {
                    Egn = "2222222222",
                    Biography = "A",
                    Education= "B",
                    Id= "6",
                    ProfileImageUrl = "http://2",
                    Representation = "C",
                    SheduleId = 1,
                    SpecialtyId = 1,
                    User = users[1],
                    UserId = users[1].Id
                },
                new Doctor()
                {
                    Egn = "3333333333",
                    Biography = "D",
                    Education= "E",
                    Id= "7",
                    ProfileImageUrl = "http://1",
                    Representation = "F",
                    SheduleId = 2,
                    SpecialtyId = 3,
                    User = users[2],
                    UserId = users[2].Id
                }
            };

            var laborant = new Laborant()
            {
                Egn = "4444444444",
                Id = "7",
                User = users[1],
                UserId = users[1].Id
            };

            await data.AddRangeAsync(users);
            await data.AddAsync(laborant);
            await data.AddRangeAsync(doctors);
            await data.AddAsync(admin);
            await data.SaveChangesAsync();
        }
    }
}
