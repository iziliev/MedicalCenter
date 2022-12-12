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
            var allFutureExamination = await repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date > DateTime.Now)
                .CountAsync();

            var allUsersCount = await repository.AllReadonly<User>()
                .Where(u => u.Role == "User")
                .CountAsync();

            var oldExamination = await repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date < DateTime.Now.Date)
                .CountAsync();

            var allTest = await repository.AllReadonly<Test>()
                .CountAsync();

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
                .Include(u=>u.User)
                .OrderByDescending(x => x.DoctorReviews.Average(x => x.Rating))
                .FirstOrDefaultAsync();

            var bestExaminationDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorExaminations)
                .Include(u => u.User)
                .OrderByDescending(x => x.DoctorExaminations.Count)
                .FirstOrDefaultAsync();

            return new DashboardStatisticViewModel
            {
                BestRatingDoctorFullName = bestRatingDoctor.DoctorReviews.Count == 0 ? "Няма отзиви" : $"Д-р {bestRatingDoctor.User.FirstName} {bestRatingDoctor.User.LastName}",
                BestDoctorRating = bestRatingDoctor.DoctorReviews.Count == 0 ? "0.00" : bestRatingDoctor.DoctorReviews.Average(x => x.Rating).ToString("F2"),
                BestExaminationDoctorFullName = bestExaminationDoctor.DoctorExaminations.Count == 0 ? "Няма записани часове" : $"Д-р {bestExaminationDoctor.User.FirstName} {bestExaminationDoctor.User.LastName}",
                BestExaminationCount = bestExaminationDoctor.DoctorExaminations.Count,
            };
        }

        public async Task<DashboardStatisticViewModel> GetStatisticAdminLaboratory()
        {
            var allTest = await repository.AllReadonly<Test>()
                .CountAsync();

            return new DashboardStatisticViewModel
            {
                AllTest = allTest
            };
        }

        public async Task<DashboardStatisticViewModel> GetStatisticLaborant()
        {
            var allTest = await repository.AllReadonly<Test>()
                .CountAsync();

            var allLaboratoryPatient = await repository.AllReadonly<LaboratoryPatient>()
                .CountAsync();

            return new DashboardStatisticViewModel
            {
                AllTest = allTest,
                AllUserCount = allLaboratoryPatient
            };
        }
    }
}
