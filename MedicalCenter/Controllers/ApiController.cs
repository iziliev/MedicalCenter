using MedicalCenter.Core.Models.Api;
using MedicalCenter.Core.Services;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IRepository repository;

        public ApiController(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatistics()
        {
            var allUsersCount = repository.AllReadonly<User>()
                .Where(u => u.Role == "User")
                .ToList()
                .Count();

            var oldExamination = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date < DateTime.Now.Date)
                .ToList()
                .Count();

            var allExamination = repository.AllReadonly<Examination>()
                .Where(e => !e.IsDeleted && e.Date.Date > DateTime.Now.Date)
                .ToList()
                .Count();

            var allTest = repository.AllReadonly<Test>()
                .ToList()
                .Count();

            return Ok(new DashboardStatisticViewModel
            {
                AllExamination = allExamination,
                AllUserCount = allUsersCount,
                BestExaminationCount = oldExamination,
                AllTest = allTest
            });
        }
    }
}
