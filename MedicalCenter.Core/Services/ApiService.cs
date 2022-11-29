using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
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

        public async Task<DashboardStatisticViewModel> GetStatisticHome()
        {
            var allFutureExamination = await repository.All<Examination>()
                .Where(e => !e.IsDeleted && e.Date > DateTime.Now)
                .CountAsync();

            var allUsersCount = repository.AllReadonly<User>()
                .Where(u => u.Role == "User")
                .ToList()
                .Count();

            var oldExamination = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date < DateTime.Now.Date)
                .ToList()
                .Count();

            var allTest = repository.AllReadonly<Test>()
                .ToList()
                .Count();

            return new DashboardStatisticViewModel
            {
                AllFutureExamination = allFutureExamination,
                AllUserCount = allUsersCount,
                AllPastExamination = oldExamination,
                AllTest = allTest
            };
        }

        public async Task<DashboardStatisticViewModel> GetStatisticAdminMedical()
        {
            var bestRatingDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorReviews)
                .OrderByDescending(x => x.DoctorReviews.Average(x => x.Rating))
                .FirstOrDefaultAsync();

            var bestExaminationDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorExaminations)
                .OrderByDescending(x => x.DoctorExaminations.Count)
                .FirstOrDefaultAsync();

            return new DashboardStatisticViewModel
            {
                BestRatingDoctorFullName = bestRatingDoctor.DoctorReviews.Count == 0 ? "Няма отзиви" : $"Д-р {bestRatingDoctor.FirstName} {bestRatingDoctor.LastName}",
                BestDoctorRating = bestRatingDoctor.DoctorReviews.Count == 0 ? "0.00" : bestRatingDoctor.DoctorReviews.Average(x => x.Rating).ToString("F2"),
                BestExaminationDoctorFullName = bestExaminationDoctor.DoctorExaminations.Count == 0 ? "Няма записани часове" : $"Д-р {bestExaminationDoctor.FirstName} {bestExaminationDoctor.LastName}",
                BestExaminationCount = bestExaminationDoctor.DoctorExaminations.Count,
            };
        }

        public Task<DashboardStatisticViewModel> GetStatisticAdminLaboratory()
        {
            var allTest = repository.AllReadonly<Test>()
                .ToList()
                .Count();

            return Task.FromResult(new DashboardStatisticViewModel
            {
                AllTest = allTest
            });
        }

        public Task<DashboardStatisticViewModel> GetStatisticLaborant()
        {
            var allTest = repository.AllReadonly<Test>()
                .ToList()
                .Count();

            var allLaboratoryPatient = repository.AllReadonly<LaboratoryPatient>()
                .ToList()
                .Count();

            return Task.FromResult(new DashboardStatisticViewModel
            {
                AllTest = allTest,
                AllUserCount = allLaboratoryPatient
            });
        }
    }
}
