using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Core.Models.LaboratoryPatient;
using MedicalCenter.Core.Services;
using MedicalCenter.Extensions;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class LaboratoryPatientController : BaseController
    {
        private readonly ILaboratoryPatient laboratoryPatientService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;


        public LaboratoryPatientController(
            ILaboratoryPatient _laboratoryPatientService,
            IGlobalService _globalService,
            IRepository _repository,
            SignInManager<User> _signInManager,
            UserManager<User> _userManager)
        {
            laboratoryPatientService = _laboratoryPatientService;
            globalService = _globalService;
            repository = _repository;
            signInManager = _signInManager;
            userManager = _userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var loginModel = new LoginPatientViewModel();

            ViewData["Title"] = "Вход";

            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginPatientViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Вход";
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(loginModel);
            }

            if (!await laboratoryPatientService.IsEgnExistAsync(loginModel.Egn) && !await laboratoryPatientService.IsUsernameExistAsync(loginModel.Egn))
            {
                ViewData["Title"] = "Вход";
                ModelState.AddModelError("", ModelErrorConstants.WrongLogin);
                return View(loginModel);
            }

            var result = await laboratoryPatientService.Login(loginModel);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Title"] = "Вход";
            ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
            return View(loginModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.LaboratoryUserRole)]
        public async Task<IActionResult> AllResult([FromQuery] ShowAllLaboratoryPatientResultViewModel query)
        {
            var userId = User.Id();

            var queryResult = await laboratoryPatientService.GetAllResult(
                userId,
                query.SearchTermDate,
                query.CurrentPage,
                ShowAllDoctorViewModel.DoctorsPerPage);

            ViewData["Title"] = "Всички доктори";

            query.TotalResultCount = queryResult.TotalResultCount;
            query.AllResults = queryResult.AllResults;

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.LaboratoryUserRole)]
        public async Task<IActionResult> ViewResult(string id)
        {
            var modelResult = await laboratoryPatientService.GetResultByIdAsync(id);

            ViewData["Title"] = "Всички доктори";

            return View(modelResult);
        }

    }
}
