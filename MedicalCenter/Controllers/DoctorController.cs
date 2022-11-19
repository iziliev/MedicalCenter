using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Extensions;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorService doctorService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;

        public DoctorController(
            IDoctorService _doctorService,
            IGlobalService _globalService,
            IRepository _repository)
        {
            doctorService = _doctorService;
            globalService = _globalService;
            repository = _repository;
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

            var doctor = await repository.GetByIdAsync<Doctor>(doctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            ViewData["DoctorName"] = $"д-р {doctor.FirstName} {doctor.LastName}";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DoctorStatistic()
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

            var doctor = await repository.GetByIdAsync<Doctor>(doctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                ViewData["Title"] = "Табло на ";
                return View();
            }

            var allExaminationModel = new DoctorExaminationInfo
            {
                DoctorExaminations = await doctorService.GetAllExaminationAsync(doctor),
                DoctorStatistics = await doctorService.GetDoctorStatisticsAsync(doctor),
            };

            return View(allExaminationModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.DoctorRole)]
        public async Task<IActionResult> AllDoctorExamination([FromQuery]ShowAllExaminationDoctorViewModel query)
        {
            var doctorId = User.Id();

            var queryResult = await doctorService.GetAllDoctorExaminationAsync(
                doctorId, 
                query.SearchTerm, 
                query.CurrentPage, 
                ShowAllExaminationDoctorViewModel.ExaminationPerPage);

            if (string.IsNullOrEmpty(query.SearchTerm) == false)
            {
                ViewData["Title"] = $"Записани прегледи на {query.SearchTerm}";
            }
            else
            {
                ViewData["Title"] = $"Записани прегледи";
            }

            query.TotalExaminationCount = queryResult.TotalExaminationCount;
            query.AllExamination = queryResult.AllExamination;

            return View(query);
        }
    }
}
