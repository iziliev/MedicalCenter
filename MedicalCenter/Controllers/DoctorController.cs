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

            var doctorId = User.Id();

            if (doctorId == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var doctor = await doctorService.GetDoctorByIdAsync(doctorId);

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
