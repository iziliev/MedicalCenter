using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public IActionResult SearchDoctor()
        {
            var searchModel = new SearchDoctorViewModel();

            ViewData["Title"] = "Проверка на доктор по ЕГН";

            return View(searchModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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

            return RedirectToAction(nameof(CreateDoctor), doctor);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> EditDoctor(string id)
        {
            var doctorEditModel = await administratorService.GetDoctorByIdToEditAsync(id);

            doctorEditModel = await globalService.FillGendersSpecialitiesSheduleInEditViewAsyanc(doctorEditModel);

            ViewData["Title"] = "Редактиране на доктор";

            return View(doctorEditModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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

            return RedirectToAction(nameof(AdminBoard));
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> CreateDoctor()
        {
            var doctorCreateModel = new CreateDoctorViewModel();
            doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);
            
            ViewData["Title"] = "Добавяне на доктор";

            return View(doctorCreateModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> CreateDoctor(CreateDoctorViewModel doctorCreateModel)
        {
            if (!ModelState.IsValid)
            {
                doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

                return View(doctorCreateModel);
            }

            var result = await administratorService.CreateDoctorAsync(doctorCreateModel);

            var doctor = await administratorService.GetDoctorByEgnAsync(doctorCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddDoctorRoleAsync(doctor, RoleConstants.DoctorRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctorCreateModel.FirstName} {doctorCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoard));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            doctorCreateModel = await globalService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

            return View(doctorCreateModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await repository.GetByIdAsync<Doctor>(id);

            await administratorService.DeleteDoctorAsync(id);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит д-р {doctor.FirstName} {doctor.LastName} от Medical Center!";

            return RedirectToAction(nameof(AdminBoard));
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> ReturnDoctor(string id)
        {   
            var doctor = await repository.GetByIdAsync<Doctor>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctor.FirstName} {doctor.LastName} в Medical Center!";

            await administratorService.ReturnDoctorAsync(id);

            return RedirectToAction(nameof(AdminBoard));
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> AdminBoard()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
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
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> StatisticData()
        {
            var modelStatistic = await administratorService.GetStatisticsDataAsync();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }
    }
}
