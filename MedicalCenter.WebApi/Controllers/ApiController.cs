using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiService apiService;

        public ApiController(
            IApiService _apiService)
        {
            apiService = _apiService;
        }

        [HttpGet]
        [Route("ShowDoctorByEgn")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ShowDoctorByEgn(string egn)
        {
            var doctor = await apiService.GetDoctorByEgnAsync(egn);

            return Ok(doctor);
        }

        [HttpGet]
        [Route("ShowTestById")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(TestModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ShowTestById(string id)
        {
            var test = await apiService.GetTestByIdAsync(id);

            return Ok(test);
        }

        [HttpGet]
        [Route("Statistics")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Statistics()
        {
            var statistic = await apiService.GetInfo();

            return Ok(statistic);
        }

        [HttpGet]
        [Route("AllDoctors")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DoctorModel>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AllDoctors()
        {
            var doctors = await apiService.GetAllDoctors();

            return Ok(doctors);
        }
    }
}
