using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using MedicalCenter.Test.Mocks;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace MedicalCenter.Test.UnitTests
{
    public class UnitTestBase
    {
        protected IRepository data;
        protected IDateTimeService dateTimeService;
        protected UserManager<User> usermanagerMock;

        [OneTimeSetUp]
        public async Task SetUpBase()
        {
            usermanagerMock= UsermanagerMock.CreateUserManager();
            dateTimeService = new DateTimeService();
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
                new User(){Id="1",Email="admin@mail.bg",FirstName="Admin",LastName="Adminov",GenderId=1,JoinOnDate=dateTimeService.GetDate(),Role="Administrator",UserName="admin",AdministratorId="1"},

                new User(){Id="2",Email="doctor1@mail.bg",FirstName="Doctor1",LastName="Doctorov1",GenderId=1,JoinOnDate=dateTimeService.GetDate(),Role="Doctor",UserName="doctor1",DoctorId="1",PhoneNumber="+359999999"},
                new User(){Id="3",Email="doctor2@mail.bg",FirstName="Doctor2",LastName="Doctorov2",GenderId=2,JoinOnDate=dateTimeService.GetDate(),Role="Doctor",UserName="doctor2",DoctorId="2",PhoneNumber="+359888888"},

                new User(){Id="4",Email="laborant@mail.bg",FirstName="Laborant",LastName="Laborantov",GenderId=1,JoinOnDate=dateTimeService.GetDate(),Role="Laborant",UserName="laborant",LaborantId="1"},

                new User(){Id="5",Email="user1@mail.bg",FirstName="User1",LastName="Userov1",GenderId=1,JoinOnDate=dateTimeService.GetDate(),Role="User",UserName="user1",PhoneNumber="+359666666"},
                new User(){Id="6",Email="user2@mail.bg",FirstName="User2",LastName="Userov2",GenderId=2,JoinOnDate=dateTimeService.GetDate(),Role="User",UserName="user2",PhoneNumber="+359777777"},

                new User(){Id="7",Email="pat@mail.bg",FirstName="Patient",LastName="Patientov",GenderId=1,JoinOnDate=dateTimeService.GetDate(),Role="LaboratoryPatient",UserName="pat_1",LaboratoryPatientId="1"},

            };

            var admin = new Administrator() { Egn = "1111111111", Id = "1", User = users[0], UserId = users[0].Id };

            var doctors = new List<Doctor>()
            {
                new Doctor(){ Egn = "2222222222",Biography = "A",Education= "B",Id= "1",ProfileImageUrl = "http://2",Representation = "C",SheduleId = 1,SpecialtyId = 1,User = users[1],UserId = users[1].Id },
                new Doctor(){ Egn = "3333333333",Biography = "D",Education= "E",Id= "2",ProfileImageUrl = "http://1",Representation = "F",SheduleId = 2,SpecialtyId = 3,User = users[2],UserId = users[2].Id }
            };

            var laborant = new Laborant() { Egn = "4444444444", Id = "1", User = users[3], UserId = users[3].Id };

            var laboratoryPatient = new LaboratoryPatient { Egn = "8989898989", Id = "1", User = users[6], UserId = users[6].Id };

            var shedule = new List<Shedule>()
            {
                new Shedule()
                {
                    Id = 1, Name ="1", Doctors = new List<Doctor>(){doctors[0]}
                },
                new Shedule()
                {
                    Id = 2,Name = "2", Doctors = new List<Doctor>(){ doctors[1]}
                }
            };

            var workHours = new List<WorkHour>()
            {
                new WorkHour() {Id = 1, Hour ="08:00",SheduleId=1},
                new WorkHour() {Id = 2, Hour ="09:00",SheduleId=1},
                new WorkHour() {Id = 3, Hour ="15:00",SheduleId=2},
                new WorkHour() {Id = 4, Hour ="16:00",SheduleId=2},
            };

            var review = new Review()
            {
                Id = "1",
                Content = "AAAAA",
                CreatedOn = DateTime.Now,
                Doctor = doctors[0],
                DoctorId = doctors[0].Id,
                Rating = 4,
                User = users[4],
                UserId = users[4].Id
            };

            doctors[0].DoctorReviews.Add(review);
            users[4].UserReviews.Add(review);

            var examinations = new List<Examination>()
            {
                new Examination{Id="1",Date = DateTime.Parse("05.01.2023"),Doctor=doctors[0],DoctorFullName=$"{doctors[0].User.FirstName} {doctors[0].User.LastName}",DoctorId=doctors[0].Id,Hour="08:30",SheduleId=1,User = users[4],UserId=users[4].Id,UserFullName=$"{users[4].FirstName} {users[4].LastName}",SpecialityId=1, DoctorPhoneNumber=doctors[0].User.PhoneNumber,UserPhoneNumber=users[4].PhoneNumber },
                new Examination{Id="2",Date = DateTime.Parse("02.11.2022"),Doctor=doctors[0],DoctorFullName=$"{doctors[0].User.FirstName} {doctors[0].User.LastName}",DoctorId=doctors[0].Id,Hour="10:30",SheduleId=1,User = users[4],UserId=users[4].Id,UserFullName=$"{users[4].FirstName} {users[4].LastName}",SpecialityId=1,DoctorPhoneNumber=doctors[0].User.PhoneNumber,UserPhoneNumber=users[4].PhoneNumber, ReviewId="1",IsUserReviewedExamination=true }
            };

            var test = new Infrastructure.Data.Models.Test()
            {
                Id = "1",
                LaboratoryPatientId = laboratoryPatient.Id,
                LaboratoryPatient = laboratoryPatient,
                TestDate = DateTime.Now,
                UrinepH = "1.5"
            };

            await data.AddRangeAsync(gender);
            await data.AddRangeAsync(speciality);
            await data.AddRangeAsync(users);
            await data.AddAsync(laborant);
            await data.AddRangeAsync(doctors);
            await data.AddAsync(admin);
            await data.AddAsync(laboratoryPatient);
            await data.AddRangeAsync(shedule);
            await data.AddRangeAsync(workHours);
            await data.AddRangeAsync(examinations);
            await data.AddAsync(test);
            await data.AddAsync(review);
            await data.SaveChangesAsync();
        }
    }
}
