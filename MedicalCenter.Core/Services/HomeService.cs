using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            var allUsersCount = repository.AllReadonly<User>()
                .Where(u => u.Role == "User")
                .Count();

            var oldExamination = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date<DateTime.Now.Date)
                .Count();

            var allExamination = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date > DateTime.Now.Date)
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
