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

            var speciality = new List<Specialty>()
            {
                new Specialty() {Id = 1, Name ="A"},
                new Specialty() {Id = 2, Name ="B"},
                new Specialty() {Id = 3, Name ="C"}
            };

            var gender = new List<Gender>()
            {
                new Gender() {Id = 1, Name ="M"},
                new Gender() {Id = 2, Name ="F"},
                new Gender() {Id = 3, Name ="O"}
            };

            

            var users = new List<User>()
            {
                new User(){Id="1",Email="admin@mail.bg",FirstName="Admin",LastName="Adminov",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Administrator",UserName="admin",AdministratorId="5"},
                new User(){Id="2",Email="doctor1@mail.bg",FirstName="Doctor1",LastName="Doctorov1",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Doctor",UserName="doctor1",DoctorId="6"},
                new User(){Id="3",Email="doctor2@mail.bg",FirstName="Doctor2",LastName="Doctorov2",GenderId=2,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Doctor",UserName="doctor2",DoctorId="7"},
                new User(){Id="4",Email="laborant@mail.bg",FirstName="Laborant",LastName="Laborantov",GenderId=1,JoinOnDate=DateTime.Now.ToString("dd.MM.yyyy"),Role="Laborant",UserName="laborant",LaborantId="8"}
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
                Id = "8",
                User = users[1],
                UserId = users[1].Id
            };

            var shedule = new List<Shedule>()
            {
                new Shedule() 
                {
                    Id = 1, 
                    Name ="1" ,
                    Doctors = new List<Doctor>()
                    {
                        doctors[0]
                    } 
                },
                new Shedule() 
                { 
                    Id = 2, 
                    Name = "2", 
                    Doctors = new List<Doctor>() 
                    { 
                        doctors[1] 
                    } 
                }
            };

            var workHours = new List<WorkHour>()
            {
                new WorkHour() {Id = 1, Hour ="08:00",SheduleId=1},
                new WorkHour() {Id = 2, Hour ="09:00",SheduleId=1},
                new WorkHour() {Id = 3, Hour ="15:00",SheduleId=2},
                new WorkHour() {Id = 4, Hour ="16:00",SheduleId=2},
            };

            await data.AddRangeAsync(gender);
            await data.AddRangeAsync(speciality);
            await data.AddRangeAsync(users);
            await data.AddAsync(laborant);
            await data.AddRangeAsync(doctors);
            await data.AddAsync(admin);
            await data.AddRangeAsync(shedule);
            await data.AddRangeAsync(workHours);
            await data.SaveChangesAsync();
        }
    }
}
