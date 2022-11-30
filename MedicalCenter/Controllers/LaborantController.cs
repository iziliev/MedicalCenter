using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Laborant;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{

    [Authorize(Roles = RoleConstants.LaborantRole)]
    public class LaborantController : BaseController
    {
        private readonly ILaborantService laborantService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;

        public LaborantController(
            ILaborantService _laborantService,
            IGlobalService _globalService,
            IRepository _repository)
        {
            laborantService = _laborantService;
            globalService = _globalService;
            repository = _repository;
        }

        [HttpGet]
        public IActionResult SearchLaboratoryPatient()
        {
            var searchModel = new SearchLaboratoryPatientViewModel();

            ViewData["Title"] = "Проверка на съществуващ пациент по ЕГН";

            return View(searchModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchLaboratoryPatient(SearchLaboratoryPatientViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(searchModel);
            }

            var laboratoryPatient = await laborantService.SearchLaboratoryPatientByEgnAsync(searchModel.Egn);

            if (laboratoryPatient == null)
            {
                return RedirectToAction(nameof(CreateLaboratoryPatient));
            }

            ModelState.AddModelError("", ModelErrorConstants.LaboratoryPatientExistError);
            ViewData["Title"] = "Проверка на съществуващ пациент по ЕГН";
            return View(new SearchLaboratoryPatientViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> CreateLaboratoryPatient()
        {
            var laboratoryPatientCreateModel = new CreateLaboratoryPatientViewModel();

            laboratoryPatientCreateModel.Genders = await globalService.GetGendersAsync();

            ViewData["Title"] = "Добавяне на потребител";

            return View(laboratoryPatientCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaboratoryPatient(CreateLaboratoryPatientViewModel laboratoryPatientCreateModel)
        {
            laboratoryPatientCreateModel.Username = $"pat_{laboratoryPatientCreateModel.Egn}";

            if (!ModelState.IsValid)
            {
                laboratoryPatientCreateModel.Genders = await globalService.GetGendersAsync();
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(laboratoryPatientCreateModel);
            }

            var result = await laborantService.CreateLaboratoryPatientAsync(laboratoryPatientCreateModel);

            var laboratoryPatient = await laborantService.GetLaboratoryPatientByEgnAsync(laboratoryPatientCreateModel.Egn);

            if (result.Succeeded)
            {
                await laborantService.AddLaboratoryPatientRoleAsync(laboratoryPatient.User, RoleConstants.LaboratoryUserRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен {laboratoryPatientCreateModel.FirstName} {laboratoryPatientCreateModel.LastName}!";

                return RedirectToAction(nameof(LaborantBoard));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            laboratoryPatientCreateModel.Genders = await globalService.GetGendersAsync();

            return View(laboratoryPatientCreateModel);
        }

        [HttpGet]
        public IActionResult LaborantBoard()
        {
            ViewData["Title"] = "Laborant panel";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AllLaboratoryPatient([FromQuery] ShowAllLaboratoryPatientViewModel query)
        {
            var queryResult = await laborantService.GetAllCurrentLaboratoryPatientAsync(
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllLaboratoryPatientViewModel.LaboratoryPatientPerPage);

            ViewData["Title"] = "Всички пациенти";

            query.TotalLaboratoryPatientCount = queryResult.TotalLaboratoryPatientCount;
            query.LaboratoryPatients = queryResult.LaboratoryPatients;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> UploadResult(string patientId)
        {
            var laboratoryPatient = await repository.GetByIdAsync<LaboratoryPatient>(patientId);

            var model = new UploadTestResultViewModel
            {
                LaboratoryPatient = laboratoryPatient
            };

            ViewData["Title"] = $"Резултат на пациент с ЕГН: {laboratoryPatient.Egn}";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadResult(UploadTestResultViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = $"Резултат на пациент с ЕГН: {model.LaboratoryPatient.Egn}";
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(model);
            }

            await laborantService.UploadResultAsync(model);
            return RedirectToAction(nameof(LaborantBoard));
        }
    }
}
