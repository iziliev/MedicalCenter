using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class AdministratorController : BaseController
    {
        private readonly IAdministratorService administratorService;
        private readonly IGlobalService globalService;

        public AdministratorController(IAdministratorService _administratorService,
            IGlobalService _globalService)
        {
            administratorService = _administratorService;
            globalService = _globalService;
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

            var doctor = await administratorService.SearchDoctorAsync(searchModel.Egn);

            if (doctor == null)
            {
                return RedirectToAction("CreateDoctor", "Administrator");
            }

            if (!doctor.IsOutOfCompany)
            {
                ModelState.AddModelError("", ModelErrorConstants.DoctorExistError);
                return View(searchModel);
            }

            return RedirectToAction("CreateDoctor", doctor);
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

            var doctor = await administratorService.GetDoctorByIdAsync(doctorEditModel.Id);

            if (doctor != null)
            {
                await administratorService.EditDoctorAsync(doctorEditModel, doctor);
            }

            return RedirectToAction("Index", "Home");
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

            if (doctorCreateModel.Id != null && doctorCreateModel.IsOutOfCompany)
            {
                await administratorService.ReturnDoctorAsync(doctorCreateModel.Id);

                ViewBag.CreateDoctor = $"Успешно е добавен д-р {doctorCreateModel.FirstName} {doctorCreateModel.LastName} в Medical Center!";

                return View();
            }

            var result = await administratorService.CreateDoctorAsync(doctorCreateModel);

            var doctor = await administratorService.GetDoctorByEgnAsync(doctorCreateModel.Egn);

            if (result.Succeeded)
            {
                await administratorService.AddDoctorRoleAsync(doctor, RoleConstants.DoctorRole);

                ViewBag.CreateDoctor = $"Успешно е добавен д-р {doctorCreateModel.FirstName} {doctorCreateModel.LastName} в Medical Center!";

                return RedirectToAction("AdminBoard", "Administrator");
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
            await administratorService.DeleteDoctorAsync(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> ReturnDoctor(string id)
        {
            await administratorService.ReturnDoctorAsync(id);

            return RedirectToAction("Index", "Home");
        }


        //[Authorize(Roles = AdministratorRole)]
        public async Task<IActionResult> CreateRoles()
        {
            await globalService.CreateRoleAsync();

            return RedirectToAction("Index", "Home");
        }

        //[Authorize(Roles = AdministratorRole)]
        public async Task<IActionResult> AddUsersToRoles()
        {
            await globalService.AddUsersToRoleAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> AllDoctor()
        {
            var allDoctors = new ShowAllDoctorViewModel()
            {
                AllDoctors = await administratorService.GetAllCurrentDoctorsAsync()
            };

            ViewData["Title"] = "доктори";

            return View(allDoctors);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> AllDoctorOut()
        {
            var doctors = new ShowAllDoctorViewModel()
            {
                AllDoctors = await administratorService.GetAllLeftDoctorsAsync()
            };

            ViewData["Title"] = "изтрити";

            return View(doctors);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> AllUser()
        {
            var users = new ShowAllUserViewModel()
            {
                AllUsers = await administratorService.GetAllRegisteredUsersAsync()
            };

            ViewData["Title"] = "пациенти";

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.AdministratorRole)]
        public async Task<IActionResult> AdminBoard()
        {
            var modelStatistic = await administratorService.GetStatisticsAsync();

            ViewData["Title"] = "Admin panel";
            return View(modelStatistic);
        }
    }
}
