using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Core.Services
{
    public class ApiService : IApiService
    {
        private readonly IRepository repository;

        public ApiService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<DoctorModel> GetDoctorByEgnAsync(string egn)
        {
            var doctor = await repository.AllReadonly<Doctor>()
                .Include(x => x.Specialty)
                .Include(x => x.Shedule)
                .Where(x => x.Egn == egn)
                .FirstOrDefaultAsync();

            if (doctor == null)
            {
                return null;
            }

            return new DoctorModel
            {
                Name = $"д-р {doctor.FirstName} {doctor.LastName}",
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                SheduleName = doctor.Shedule.Name,
                SpecialityName = doctor.Specialty.Name
            };
        }

        public async Task<StatisticsModel> GetInfo()
        {
            var allDoctors = await repository.AllReadonly<Doctor>()
                .Where(x => !x.IsOutOfCompany)
                .CountAsync();

            var allUsers = await repository.AllReadonly<User>()
                .CountAsync();

            var allExamination = await repository.AllReadonly<Examination>()
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var allLaborants = await repository.AllReadonly<Laborant>()
                .Where(x => !x.IsOutOfCompany)
                .CountAsync();

            var allLaboratoryPatients = await repository.AllReadonly<LaboratoryPatient>()
                .CountAsync();

            var AllTests = await repository.AllReadonly<Test>()
                .CountAsync();

            return new StatisticsModel
            {
                AllDoctors = allDoctors,
                AllExamination = allExamination,
                AllLaborants = allLaborants,
                AllLaboratoryPatients = allLaboratoryPatients,
                AllTests = AllTests,
                AllUsers = allUsers
            };
        }

        public async Task<TestModel> GetTestByIdAsync(string testId)
        {
            var test = await repository.AllReadonly<Test>()
                .Where(x => x.Id == testId)
                .FirstOrDefaultAsync();

            if (test == null)
            {
                return null;
            }

            return new TestModel
            {
                PatientName = $"{test.LaboratoryPatient.FirstName} {test.LaboratoryPatient.LastName}",
                PatientEgn = test.LaboratoryPatient.Egn,
                Date = test.TestDate.ToString("dd.MM.yyyy"),
                Hct = test.Hct,
                Hgb = test.Hgb,
                MCH = test.MCH,
                MCHC = test.MCHC,
                MCV = test.MCV,
                Plt = test.Plt,
                RBC = test.RBC,
                UrineGravity = test.UrineGravity,
                UrinepH = test.UrinepH,
                WBC = test.WBC
            };
        }

        public async Task<IEnumerable<DoctorModel>> GetAllDoctors()
        {
            var doctors = await repository.AllReadonly<Doctor>()
                .Include(x => x.Shedule)
                .Include(x => x.Specialty)
                .Select(x => new DoctorModel
                {
                    Name = $"д-р {x.FirstName} {x.LastName}",
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    SpecialityName = x.Specialty.Name,
                    SheduleName = x.Shedule.Name,

                })
                .OrderBy(x=>x.SpecialityName)
                .ToListAsync();

            return doctors;
        }
    }
}
