using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository _repository)
        {
            repository = _repository;
        }

        public DashboardStatisticViewModel Statistics()
        {
            var allUsersCount = repository.All<User>()
                .Where(u => u.Role == "User")
                .ToList()
                .Count();

            var oldExamination = repository.All<Examination>()
                .Where(e => !e.IsDeleted && e.Date<DateTime.Now)
                .ToList()
                .Count();

            var allExamination = repository.All<Examination>()
                .Where(e => !e.IsDeleted)
                .ToList()
                .Count();

            return new DashboardStatisticViewModel
            { 
                AllExamination = allExamination,
                AllUserCount = allUsersCount,
                BestExaminationCount = oldExamination,
            };
        }
    }
}
