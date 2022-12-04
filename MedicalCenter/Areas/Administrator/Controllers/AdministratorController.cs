using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Controllers;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Extensions;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = RoleConstants.AdministratorRole)]
    public class AdministratorController : BaseController
    {
        private readonly IAdministratorService administratorService;
        private readonly IRepository repository;

        public AdministratorController(
            IAdministratorService _administratorService,
            IRepository _repository)
        {
            administratorService = _administratorService;
            repository = _repository;
        }
        
        [HttpGet]
        public IActionResult SearchAdministrator()
        {
            var searchModel = new SearchAdminViewModel();

            ViewData["Title"] = "Проверка на администратор по ЕГН";

            return View(searchModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchAdministrator(SearchAdminViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(searchModel);
            }

            var administrator = await administratorService.SearchUserByEgnAsync<CreateAdminViewModel,Infrastructure.Data.Models.Administrator>(searchModel.Egn);

            if (administrator == null)
            {
                return RedirectToAction(nameof(CreateAdministrator));
            }

            if (!administrator.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.DoctorExistError);
                return View(searchModel);
            }

            if (administrator.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.DoctorOutExistError);
                return View(searchModel);
            }

            return RedirectToAction(nameof(CreateAdministrator), administrator);
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

            var doctor = await administratorService.SearchUserByEgnAsync<CreateDoctorViewModel,Doctor>(searchModel.Egn);

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

            var laborant = await administratorService.SearchUserByEgnAsync<CreateLaborantViewModel,Laborant>(searchModel.Egn);

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
        public async Task<IActionResult> EditAdministrator(string id)
        {
            var adminEditModel = await administratorService.GetUserByIdToEditAsync<MainAdminViewModel,Infrastructure.Data.Models.Administrator>(id);
            adminEditModel.Genders = await administratorService.GetGendersAsync();
            ViewData["Title"] = "Редактиране на администратор";

            return View(adminEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAdministrator(MainAdminViewModel adminEditModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Редактиране на администратор";
                adminEditModel.Genders = await administratorService.GetGendersAsync();
                return View(adminEditModel);
            }

            var administrator = await administratorService.GetUserByIdAsync<Infrastructure.Data.Models.Administrator>(adminEditModel.Id);

            if (administrator != null)
            {
                TempData[MessageConstant.WarningMessage] = $"Успешно е редактиран админ {administrator.User.FirstName} {administrator.User.LastName}!";
                adminEditModel.Genders = await administratorService.GetGendersAsync();
                await administratorService.EditUserAsync<MainAdminViewModel, Infrastructure.Data.Models.Administrator>(adminEditModel, administrator);
            }

            return RedirectToAction(nameof(AdminBoardAdministrator));
        }

        [HttpGet]
        public async Task<IActionResult> EditDoctor(string id)
        {
            var doctorEditModel = await administratorService.GetUserByIdToEditAsync<MainDoctorViewModel, Doctor>(id);

            doctorEditModel = await administratorService.FillGendersSpecialitiesSheduleInEditViewAsyanc(doctorEditModel);

            ViewData["Title"] = "Редактиране на доктор";

            return View(doctorEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(MainDoctorViewModel doctorEditModel)
        {
            if (!ModelState.IsValid)
            {
                doctorEditModel = await administratorService.FillGendersSpecialitiesSheduleInEditViewAsyanc(doctorEditModel);

                ViewData["Title"] = "Редактиране на доктор";

                return View(doctorEditModel);
            }

            var doctor = await administratorService.GetUserByIdAsync<Doctor>(doctorEditModel.Id);

            if (doctor != null)
            {
                TempData[MessageConstant.WarningMessage] = $"Успешно е редактиран д-р {doctor.User.FirstName} {doctor.User.LastName}!";

                await administratorService.EditUserAsync<MainDoctorViewModel,Doctor>(doctorEditModel, doctor);
            }

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpGet]
        public async Task<IActionResult> EditLaborant(string id)
        {
            var laborantEditModel = await administratorService.GetUserByIdToEditAsync<MainLaborantViewModel, Laborant>(id);

            laborantEditModel.Genders = await administratorService.GetGendersAsync();

            ViewData["Title"] = "Редактиране на доктор";

            return View(laborantEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditLaborant(MainLaborantViewModel laborantEditModel)
        {
            if (!ModelState.IsValid)
            {
                laborantEditModel.Genders = await administratorService.GetGendersAsync();

                ViewData["Title"] = "Редактиране на лаборант";

                return View(laborantEditModel);
            }

            var laborant = await administratorService.GetUserByIdAsync<Laborant>(laborantEditModel.Id);

            if (laborant != null)
            {
                TempData[MessageConstant.WarningMessage] = $"Успешно е редактиран лаборант {laborant.User.FirstName} {laborant.User.LastName}!";

                await administratorService.EditUserAsync<MainLaborantViewModel,Laborant>(laborantEditModel, laborant);
            }

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdministrator()
        {
            var adminCreateModel = new CreateAdminViewModel();
            adminCreateModel.Genders = await administratorService.GetGendersAsync();
            ViewData["Title"] = "Добавяне на администратор";

            return View(adminCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdministrator(CreateAdminViewModel adminCreateModel)
        {
            if (!ModelState.IsValid)
            {
                adminCreateModel.Genders = await administratorService.GetGendersAsync();
                return View(adminCreateModel);
            }

            var result = await administratorService.CreateUserAsync(adminCreateModel);

            var administrator = await administratorService.GetByEgnAsync<Infrastructure.Data.Models.Administrator>(adminCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddRoleAsync(administrator.User, RoleConstants.AdministratorRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен админ {adminCreateModel.FirstName} {adminCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoardAdministrator));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            adminCreateModel.Genders = await administratorService.GetGendersAsync();
            return View(adminCreateModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            var doctorCreateModel = new CreateDoctorViewModel();
            doctorCreateModel = await administratorService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);
            
            ViewData["Title"] = "Добавяне на доктор";

            return View(doctorCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorViewModel doctorCreateModel)
        {
            if (!ModelState.IsValid)
            {
                doctorCreateModel = await administratorService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

                return View(doctorCreateModel);
            }

            var result = await administratorService.CreateUserAsync(doctorCreateModel);

            var doctor = await administratorService.GetByEgnAsync<Doctor>(doctorCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddRoleAsync(doctor.User, RoleConstants.DoctorRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctorCreateModel.FirstName} {doctorCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoardMedicalCenter));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            doctorCreateModel = await administratorService.FillGendersSpecialitiesSheduleInCreateViewAsyanc(doctorCreateModel);

            return View(doctorCreateModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLaborant()
        {
            var laborantCreateModel = new CreateLaborantViewModel();
            laborantCreateModel.Genders = await administratorService.GetGendersAsync();

            ViewData["Title"] = "Добавяне на лаборант";

            return View(laborantCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaborant(CreateLaborantViewModel laborantCreateModel)
        {
            if (!ModelState.IsValid)
            {
                laborantCreateModel.Genders = await administratorService.GetGendersAsync();

                return View(laborantCreateModel);
            }

            var result = await administratorService.CreateUserAsync(laborantCreateModel);

            var laborant = await administratorService.GetByEgnAsync<Laborant>(laborantCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddRoleAsync(laborant.User, RoleConstants.LaborantRole);

                TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен лаборант {laborantCreateModel.FirstName} {laborantCreateModel.LastName} в Medical Center!";

                return RedirectToAction(nameof(AdminBoardLaboratory));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            laborantCreateModel.Genders = await administratorService.GetGendersAsync();

            return View(laborantCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdministrator(string id)
        {
            var admin = await repository.GetByIdAsync<Infrastructure.Data.Models.Administrator>(id);

            if (User.Id() != id)
            {
                await administratorService.DeleteAsync<Infrastructure.Data.Models.Administrator>(id);

                TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит админ {admin.User.FirstName} {admin.User.LastName} от Medical Center!";
                return RedirectToAction(nameof(AdminBoardAdministrator));
            }

            TempData[MessageConstant.ErrorMessage] = $"Не Успешно е изтрит админ {admin.User.FirstName} {admin.User.LastName} от Medical Center!";

            return RedirectToAction(nameof(AllAdministrator));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await repository.GetByIdAsync<Doctor>(id);
            
            await administratorService.DeleteAsync<Doctor>(id);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит д-р {doctor.User.FirstName} {doctor.User.LastName} от Medical Center!";

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLaborant(string id)
        {
            var laborant = await repository.GetByIdAsync<Laborant>(id);

            await administratorService.DeleteAsync<Laborant>(id);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит лаборант {laborant.User.FirstName} {laborant.User.LastName} от Medical Center!";

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnAdministrator(string id)
        {
            var admin = await administratorService.GetUserByIdAsync<Infrastructure.Data.Models.Administrator>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {admin.User.FirstName} {admin.User.LastName} в Medical Center!";

            await administratorService.ReturnAsync<Infrastructure.Data.Models.Administrator>(id);

            return RedirectToAction(nameof(AdminBoardAdministrator));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnDoctor(string id)
        {   
            var doctor = await administratorService.GetUserByIdAsync<Doctor>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен д-р {doctor.User.FirstName} {doctor.User.LastName} в Medical Center!";

            await administratorService.ReturnAsync<Doctor>(id);

            return RedirectToAction(nameof(AdminBoardMedicalCenter));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnLaborant(string id)
        {
            var laborant = await administratorService.GetUserByIdAsync<Laborant>(id);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е добавен лаборант {laborant.User.FirstName} {laborant.User.LastName} в Medical Center!";

            await administratorService.ReturnAsync<Laborant>(id);

            return RedirectToAction(nameof(AdminBoardLaboratory));
        }

        [HttpGet]
        public async Task<IActionResult> AllAdministrator([FromQuery] ShowAllAdminViewModel query)
        {
            var userId = User.Id();

            var queryResult = await administratorService.GetAllCurrentAdminAsync(
                userId,
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllAdminViewModel.AdminsPerPage);

            ViewData["Title"] = "Всички администратори";

            query.TotalAdminsCount = queryResult.TotalAdminsCount;
            query.Admins = queryResult.Admins;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllAdministratorOut([FromQuery] ShowAllAdminViewModel query)
        {
            var queryResult = await administratorService.GetAllLeftAdminAsync(
                query.SearchTermEgn,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllAdminViewModel.AdminsPerPage);

            ViewData["Title"] = "Изтрити администратори";

            query.TotalAdminsCount = queryResult.TotalAdminsCount;
            query.Admins = queryResult.Admins;

            return View(query);
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
            query.Specialties = await administratorService.GetSpecialtiesAsync();

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
            query.Specialties = await administratorService.GetSpecialtiesAsync();

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
            var modelStatistic = await administratorService.GetStatisticsAsync<DashboardStatisticViewModel>();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpGet]
        public async Task<IActionResult> AdminBoardLaboratory()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync<DashboardStatisticLabViewModel>();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpGet]
        public async Task<IActionResult> AdminBoardAdministrator()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync<DashboardStatisticAdminViewModel>();

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
            query.Specialities = await administratorService.GetSpecialtiesAsync();
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
            query.Specialities = await administratorService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticData()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync<DashboardStatisticDataViewModel>();

            ViewData["Title"] = "Admin panel";

            return View(modelStatistic);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await administratorService.Logout();

            return RedirectToAction("Index", new { controller = "Home", area = string.Empty });
        }
    }
}
