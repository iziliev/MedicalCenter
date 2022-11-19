using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MedicalCenter.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository repository;

        public DoctorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ShowAllExaminationDoctorViewModel> GetAllDoctorExaminationAsync(
            string doctorId, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var doctorExaminationQuery = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.DoctorId == doctorId)
                .Include(x => x.User)
                .Where(x => x.Date >= DateTime.Now.Date)
                .OrderByDescending(x => x.Date)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                DateTime searchDate;
                var isDate = DateTime.TryParseExact(searchTerm, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out searchDate);

                if (isDate)
                {
                    doctorExaminationQuery = doctorExaminationQuery
                    .Where(x => x.Date == searchDate);
                }
            }

            var doctorExamination = await doctorExaminationQuery
                .Skip((currentPage - 1) * examinationPerPage)
                .Take(examinationPerPage)
                .Select(d => new DashboardDoctorExaminationViewModel
                {
                    Hour = d.Hour,
                    Date = d.Date.ToString("dd.MM.yyyy"),
                    UserFullName = d.UserFullName,
                    UserPhoneNumber = d.UserPhoneNumber,
                    ExaminationId=d.Id,
                    UserId = d.UserId
                })
                .ToListAsync();

            return new ShowAllExaminationDoctorViewModel
            {
                AllExamination = doctorExamination,
                TotalExaminationCount = doctorExaminationQuery.Count(),
            };
        }

        public async Task<IEnumerable<DashboardDoctorExaminationViewModel>> GetAllExaminationAsync(Doctor doctor)
        {
            return await repository.All<Examination>()
                .Where(d => d.DoctorId == doctor.Id && !d.IsDeleted)
                .Include(x => x.User)
                .Where(x => x.Date >= DateTime.Now.Date)
                .OrderByDescending(x => x.Date)
                .Select(x => new DashboardDoctorExaminationViewModel
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

        public async Task<DoctorStatisticViewModel> GetDoctorStatisticsAsync(Doctor doctor)
        {
            var allFinishedExamination = await repository.All<Examination>()
                .Where(e => e.DoctorId == doctor.Id && !e.IsDeleted && e.Date < DateTime.Now)
                .CountAsync();

            var allExamination = await repository.All<Examination>()
                .Where(e => e.DoctorId == doctor.Id && !e.IsDeleted && e.Date.Date >= DateTime.Now.Date)
                .CountAsync();

            var ratings = await repository.All<Review>()
                .Where(r => r.DoctorId == doctor.Id)
                .ToListAsync();

            var doctorFullName = $"Д-р {doctor.FirstName} {doctor.LastName}";

            return new DoctorStatisticViewModel
            {
                AllExaminations = allExamination,
                DoctorFullName = doctorFullName,
                Examinations = allFinishedExamination,
                Rating = ratings.Count != 0 ? Math.Round(ratings.Average(r => r.Rating),2) : 0.00,
                RatingUser = ratings.Count
            };
        }
    }
}
