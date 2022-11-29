using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.WebApi.Controllers
{
    
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
        [Route("api/statisticHome")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatistics()
        {
            var info = await apiService.GetStatisticHome();

            return Ok(info);
        }

        [HttpGet]
        [Route("api/statisticAdminMedical")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatisticsAdminMedical()
        {
            var info = await apiService.GetStatisticAdminMedical();

            return Ok(info);
        }

        [HttpGet]
        [Route("api/statisticAdminLaboratory")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatisticsAdminLaboratory()
        {
            var info = await apiService.GetStatisticAdminLaboratory();

            return Ok(info);
        }

        [HttpGet]
        [Route("api/statisticLaborant")]
        [ProducesResponseType(200, Type = typeof(DoctorModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStatisticsLaborant()
        {
            var info = await apiService.GetStatisticLaborant();

            return Ok(info);
        }
    }
}
