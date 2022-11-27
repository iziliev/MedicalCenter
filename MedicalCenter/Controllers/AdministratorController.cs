using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    [Authorize(Roles = RoleConstants.AdministratorRole)]
    public class AdministratorController : BaseController
    {
        private readonly IAdministratorService administratorService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;

        public AdministratorController(
            IAdministratorService _administratorService,
            IGlobalService _globalService,
            IRepository _repository)
        {
            administratorService = _administratorService;
            globalService = _globalService;
            repository = _repository;
        }

        [HttpGet]
        public IActionResult SearchDoctor()
        {
            var searchModel = new SearchDoctorViewModel();

            ViewData["Title"] = "Проверка на доктор по ЕГН";

            return View(searchModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchDoctor(SearchDoctorViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(searchModel);
            }

            var doctor = await administratorService.SearchDoctorByEgnAsync(searchModel.Egn);

            if (doctor == null)
            {
                return RedirectToAction(nameof(CreateDoctor));
            }

            if (!doctor.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.DoctorExistError);
                return View(searchModel);
            }

            if (doctor.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.DoctorOutExistError);
                return View(searchModel);
            }

            return RedirectToAction(nameof(CreateDoctor), doctor);
        }

        [HttpGet]
        public IActionResult SearchLaborant()
        {
            var searchModel = new SearchLaborantViewModel();

            ViewData["Title"] = "Проверка на лаборант по ЕГН";

            return View(searchModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchLaborant(SearchLaborantViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(searchModel);
            }

            var laborant = await administratorService.SearchLaborantByEgnAsync(searchModel.Egn);

            if (laborant == null)
            {
                return RedirectToAction(nameof(CreateLaborant));
            }

            if (!laborant.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.LaborantExistError);
                return View(searchModel);
            }
            
            if (laborant.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.LaborantOutExistError);
                return View(searchModel);
            }

            return RedirectToAction(nameof(CreateLaborant), laborant);
        }

        [HttpGet]
        public async Task<IActionResult> EditDoctor(string id)
        {
            var doctorEditModel = await administratorService.GetDoctorByIdToEditAsync(id);

            doctorEditModel = await globalService.FillGendersSpecialitiesSheduleInEditViewAsyanc(doctorEditModel);

            ViewData["Title"] = "Редактиране на доктор";

            return View(doctorEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(MainDoctorViewModel doctorEditModel)
        {
            if (!ModelState.IsValid)
            {
                doctorEditModel = await globalService.FillGendersSpecialitiesSheduleInEditViewAsyanc(doctorEditModel);

                ViewData["Title"] = "Редактиране на доктор";

                return View(doctorEditModel);
            }

            var doctor = await repository.GetByIdAsync<Doctor>(doctorEditModel.Id);

            if (doctor != null)
            {
                TempData[MessageConstant.WarningMessage] = $"Успешно е редактиран д-р {doctor.FirstName} {doctor.LastName}!";

                await administratorService.EditDoctorAsync(doctorEditModel, doctor);
            }

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpGet]
        public async Task<IActionResult> EditLaborant(string id)
        {
            var laborantEditModel = await administratorService.GetLaborantByIdToEditAsync(id);

            laborantEditModel.Genders = await globalService.GetGendersAsync();

            ViewData["Title"] = "Редактиране на доктор";

            return View(laborantEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditLaborant(MainLaborantViewModel laborantEditModel)
        {
            if (!ModelState.IsValid)
            {
                laborantEditModel.Genders = await globalService.GetGendersAsync();

                ViewData["Title"] = "Редактиране на лаборант";

                return View(laborantEditModel);
            }

            var laborant = await repository.GetByIdAsync<Laborant>(laborantEditModel.Id);

            if (laborant != null)
            {
                TempData[MessageConstant.WarningMessage] = $"Успешно е редактиран лаборант {laborant.FirstName} {laborant.LastName}!";

                await administratorService.EditLaborantAsync(laborantEditModel, laborant);
            }

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }


        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            var doctorCreateModel = new CreateDoctorViewModel();
            doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);
            
            ViewData["Title"] = "Добавяне на доктор";

            return View(doctorCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorViewModel doctorCreateModel)
        {
            if (!ModelState.IsValid)
            {
                doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

                return View(doctorCreateModel);
            }

            var result = await administratorService.CreateDoctorAsync(doctorCreateModel);

            var doctor = await administratorService.GetByEgnAsync<Doctor>(doctorCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddDoctorRoleAsync(doctor, RoleConstants.DoctorRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctorCreateModel.FirstName} {doctorCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoardMedicalCenter));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

            return View(doctorCreateModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLaborant()
        {
            var laborantCreateModel = new CreateLaborantViewModel();
            laborantCreateModel.Genders = await globalService.GetGendersAsync();

            ViewData["Title"] = "Добавяне на лаборант";

            return View(laborantCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaborant(CreateLaborantViewModel laborantCreateModel)
        {
            if (!ModelState.IsValid)
            {
                laborantCreateModel.Genders = await globalService.GetGendersAsync();

                return View(laborantCreateModel);
            }

            var result = await administratorService.CreateLaborantAsync(laborantCreateModel);

            var laborant = await administratorService.GetByEgnAsync<Laborant>(laborantCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddLaborantRoleAsync(laborant, RoleConstants.LaborantRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен лаборант {laborantCreateModel.FirstName} {laborantCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoardLaboratory));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            laborantCreateModel.Genders = await globalService.GetGendersAsync();

            return View(laborantCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await repository.GetByIdAsync<Doctor>(id);

            await administratorService.DeleteAsync<Doctor>(id);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит д-р {doctor.FirstName} {doctor.LastName} от Medical Center!";

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLaborant(string id)
        {
            var laborant = await repository.GetByIdAsync<Laborant>(id);

            await administratorService.DeleteAsync<Laborant>(id);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит лаборант {laborant.FirstName} {laborant.LastName} от Medical Center!";

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnDoctor(string id)
        {   
            var doctor = await repository.GetByIdAsync<Doctor>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctor.FirstName} {doctor.LastName} в Medical Center!";

            await administratorService.ReturnAsync<Doctor>(id);

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnLaborant(string id)
        {
            var laborant = await repository.GetByIdAsync<Laborant>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен лаборант {laborant.FirstName} {laborant.LastName} в Medical Center!";

            await administratorService.ReturnAsync<Laborant>(id);

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }

        [HttpGet]
        public async Task<IActionResult> AllDoctor([FromQuery]ShowAllDoctorViewModel query)
        {
            var queryResult = await administratorService.GetAllCurrentDoctorsAsync(
                query.Specialty,
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllDoctorViewModel.DoctorsPerPage);

            ViewData["Title"] = "Всички доктори";

            query.TotalDoctorsCount = queryResult.TotalDoctorsCount;
            query.Doctors = queryResult.Doctors;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllDoctorOut([FromQuery]ShowAllDoctorViewModel query)
        {
            var queryResult = await administratorService.GetAllLeftDoctorsAsync(
                query.Specialty, 
                query.SearchTermEgn, 
                query.SearchTermName, 
                query.CurrentPage,
                ShowAllDoctorViewModel.DoctorsPerPage);

            ViewData["Title"] = "Изтрити доктори";

            query.TotalDoctorsCount = queryResult.TotalDoctorsCount;
            query.Doctors = queryResult.Doctors;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllLaborant([FromQuery] ShowAllLaborantViewModel query)
        {
            var queryResult = await administratorService.GetAllCurrentLaborantsAsync(
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllLaborantViewModel.LaborantPerPage);

            ViewData["Title"] = "Всички лаборанти";

            query.TotalLaborantsCount = queryResult.TotalLaborantsCount;
            query.Laborants = queryResult.Laborants;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllLaborantOut([FromQuery] ShowAllLaborantViewModel query)
        {
            var queryResult = await administratorService.GetAllLeftLaborantsAsync(
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllLaborantViewModel.LaborantPerPage);

            ViewData["Title"] = "Изтрити лаборанти";

            query.TotalLaborantsCount = queryResult.TotalLaborantsCount;
            query.Laborants = queryResult.Laborants;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllUser([FromQuery]ShowAllUserViewModel query)
        {
            var queryResult = await administratorService.GetAllRegisteredUsersAsync(
                query.SearchTermEmail, 
                query.SearchTermName,
                query.CurrentPage,
                ShowAllUserViewModel.UsersPerPage);

            ViewData["Title"] = "Потребители";

            query.TotalUsersCount = queryResult.TotalUsersCount;
            query.AllUsers = queryResult.AllUsers;

            return View(query);
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {
            ViewData["Title"] = "Admin panel";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminBoardMedicalCenter()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpGet]
        public async Task<IActionResult> AdminBoardLaboratory()
        {
            var modelStatistic = await administratorService.GetStatisticsLabAsync();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpGet]
        public async Task<IActionResult> AllPastExamination([FromQuery]ShowAllExaminationViewModel query)
        {
            var queryResult = await administratorService.GetAllPastExamination(
                query.Speciality, 
                query.SearchTermDate, 
                query.SearchTermName, 
                query.CurrentPage,
                ShowAllExaminationViewModel.ExaminationPerPage);

            ViewData["Title"] = "Извършени прегледа";

            query.TotalExaminationCount = queryResult.TotalExaminationCount;
            query.AllExamination = queryResult.AllExamination;
            query.Specialities = await globalService.GetSpecialtiesAsync();
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllFutureExamination([FromQuery]ShowAllExaminationViewModel query)
        {
            var queryResult = await administratorService.GetAllFutureExamination(
                query.Speciality,
                query.SearchTermDate,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllExaminationViewModel.ExaminationPerPage);

            ViewData["Title"] = "Предстоящи прегледa";

            query.TotalExaminationCount = queryResult.TotalExaminationCount;
            query.AllExamination = queryResult.AllExamination;
            query.Specialities = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticData()
        {
            var modelStatistic = await administratorService.GetStatisticsDataAsync();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }
    }
}
