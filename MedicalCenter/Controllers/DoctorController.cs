using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Extensions;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;
        private readonly IGlobalService globalService;

        public DoctorController(
            IDoctorService _doctorService, 
            IGlobalService _globalService)
        {
            doctorService = _doctorService;
            globalService = _globalService;
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

            var doctorId = User.Id();

            if (doctorId == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var doctor = await globalService.GetDoctorByIdAsync(doctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var allExaminationModel = new DoctorExaminationInfo
            {
                DoctorExaminations = await doctorService.GetAllExaminationAsync(doctor),
                DoctorStatistics = await doctorService.GetDoctorStatisticsAsync(doctor)
            };

            return View(allExaminationModel);
        }
    }
}
