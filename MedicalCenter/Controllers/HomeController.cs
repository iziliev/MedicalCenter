using MedicalCenter.Core.Contracts;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedicalCenter.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService _homeService)
        {
            homeService = _homeService;
        }

        public IActionResult Index()
        {
            var statisticModel = homeService.Statistics();

            return View(statisticModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}