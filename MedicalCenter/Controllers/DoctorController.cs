using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Dotor;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService _doctorService)
        {
            doctorService = _doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> DoctorBoard()
        {
            ViewData["Title"] = "Табло на ";

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var doctorId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (doctorId == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var doctor = await doctorService.GetDoctorAsync(doctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var allExaminationModel = new DoctorExaminationInfo
            {
                DoctorExaminations = await doctorService.GetAllExaminationAsync(doctor),
                DoctorStatistics = doctorService.DoctorStatistic(doctor)
            };

            return View(allExaminationModel);
        }
    }
}
