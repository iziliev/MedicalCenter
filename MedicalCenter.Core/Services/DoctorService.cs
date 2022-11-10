using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository repository;

        public DoctorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<Doctor> GetDoctorAsync(string id)
        {
            return await repository.All<Doctor>()
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<DoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor)
        {
            return await repository.All<Examination>()
                .Where(d => d.DoctorId == doctor.Id && !d.IsDeleted)
                .Include(x => x.User)
                .Where(x=>x.Date>=DateTime.Now)
                .Select(x=>new DoctorExaminationViewModel
                {
                    Date = x.Date.ToString("dd.MM.yyyy"),
                    Hour = x.Hour,
                    UserFullName = x.UserFullName,
                    UserId = x.UserId,
                    UserPhoneNumber = x.UserPhoneNumber,
                    ExaminationId = x.Id
                })
                .ToListAsync();
        }

        public DoctorStatisticViewModel DoctorStatistic(Doctor doctor)
        {
            var allFinishedExamination = repository.All<Examination>()
                .Where(e => e.DoctorId == doctor.Id && !e.IsDeleted && e.Date < DateTime.Now)
                .ToList()
                .Count();

            var allExamination = repository.All<Examination>()
                .Where(e => e.DoctorId == doctor.Id && !e.IsDeleted)
                .ToList()
                .Count();

            var ratings = repository.All<Review>()
                .Where(r => r.DoctorId == doctor.Id)
                .Select(x => x.Rating)
                .ToList();

            var doctorFullName = $"Д-р {doctor.FirstName} {doctor.LastName}";

            return new DoctorStatisticViewModel
            {
                AllExaminations = allExamination,
                DoctorFullName = doctorFullName,
                Examinations = allFinishedExamination,
                Rating = ratings.Count != 0 ? (ratings.Sum()/ratings.Count()) : 0,
                RatingUser = ratings.Count()
            };
        }
    }
}
