using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IGlobalService globalService;

        public UserController(IUserService _userService,
            IGlobalService _globalService)
        {
            userService = _userService;
            globalService = _globalService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            var registerModel = new RegisterViewModel()
            {
                Genders = await globalService.GetGendersAsync()
            };

            ViewData["Title"] = "Регистрация";

            return View(registerModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Регистрация";
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                registerModel.Genders = await globalService.GetGendersAsync();
                return View(registerModel);
            }

            if (await userService.IsUsernameExist(registerModel.Username))
            {
                ViewData["Title"] = "Регистрация";
                ModelState.AddModelError("", ModelErrorConstants.UsernameIsTaken);
                registerModel.Genders = await globalService.GetGendersAsync();
                return View(registerModel);
            }

            var result = await userService.Register(registerModel);

            if (result.Succeeded)
            {
                var user = await userService.GetUserByUsername(registerModel.Username);

                await globalService.AddUserRoleAsync(user, RoleConstants.UserRole);

                await globalService.AddClaimAsync(user);

                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            registerModel.Genders = await globalService.GetGendersAsync();
            return View(registerModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            var loginModel = new LoginViewModel(); 
            loginModel.ReturnUrl = returnUrl;

            ViewData["Title"] = "Вход";

            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Вход";
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                return View(loginModel);
            }

            if (!await userService.IsUsernameExist(loginModel.Username) && !await userService.IsEmailExist(loginModel.Username))
            {
                ViewData["Title"] = "Вход";
                ModelState.AddModelError("", ModelErrorConstants.WrongLogin);
                return View(loginModel);
            }

            var result = await userService.Login(loginModel);

            if (result.Succeeded)
            {
                if (loginModel.ReturnUrl != null)
                {
                    return Redirect(loginModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            ViewData["Title"] = "Вход";
            ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();

            return RedirectToAction("Index", "Home");
        }

        //[Authorize(Roles = AdministratorRole)]
        public async Task<IActionResult> AddUsersToRoles()
        {
            await globalService.AddUsersToRoleAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.UserRole}")]
        public async Task<IActionResult> Book(string doctorId)
        {
            var model = await userService.FillBookViewModel(doctorId);            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.UserRole}")]
        public async Task<IActionResult> Book(BookExaminationViewModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            var date = DateTime.Parse(bookModel.Date);

            if (date == DateTime.Now.Date && TimeSpan.Parse(bookModel.Hour) <= DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1)))
            {
                ModelState.AddModelError("", ModelErrorConstants.WrongHourExaminationError);
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", ModelErrorConstants.WeekendExaminationError);
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            var username = User.Identity?.Name;

            var user = await userService.GetUserByUsername(username);

            if (user == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            var doctor = await userService.GetDoctorById(bookModel.DoctorId);

            if (user == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }


            if (!await userService.IsUserFreeOnDateAnHour(user.Id, bookModel))
            {
                var examination = await userService.GetExaminationAsync(user.Id, bookModel);

                ModelState.AddModelError("", $"Вече имате записан час при {examination.DoctorFullName} на {bookModel.Date} от {bookModel.Hour}.");
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            if (!await userService.IsDoctorFreeOnDateAnHour(bookModel))
            {
                ModelState.AddModelError("", $"На {bookModel.Date} часът {bookModel.Hour} е зает.");
                bookModel.WorkHours = await userService.GetWorkHoursByDoctorId(bookModel.DoctorId);
                return View(bookModel);
            }

            await userService.CreateExamination(user, doctor, bookModel);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е записан час при д-р {doctor.FirstName} {doctor.LastName} - {bookModel.Date} {bookModel.Hour}!";

            return RedirectToAction(nameof(UserExamination));
        }

        [HttpGet]
        public async Task<IActionResult> UserExamination(ShowAllUserExaminationViewModel query)
        {
            var username = User.Identity?.Name;
            var user = await userService.GetUserByUsername(username);

            var queryResult = await userService.GetAllCurrentExamination(user.Id,query.CurrentPage,
                ShowAllUserExaminationViewModel.ExaminationsPerPage);

            ViewData["Title"] = "Предстоящи часове за прегледи";

            query.TotalExaminationCount = queryResult.TotalExaminationCount;
            query.Examinations = queryResult.Examinations;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CancelExamination(string examinationId)
        {
            var examination = await userService.GetExaminationById(examinationId);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит час при {examination.DoctorFullName} - {examination.Date} {examination.Hour}!";

            await userService.CancelUserExamination(examinationId);

            return RedirectToAction(nameof(UserExamination));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserBoard(ShowAllDoctorUserViewModel query)
        {
            var queryResult = await userService.ShowDoctorOnUser(query.CurrentPage,
                ShowAllDoctorUserViewModel.DoctorsPerPage);

            ViewData["Title"] = "Запази час";

            query.TotalDoctorsCount = queryResult.TotalDoctorsCount;
            query.Doctors = queryResult.Doctors;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> ExaminationForFeedback(ShowAllExaminationForReviewViewModel query)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var queryResult = await userService.GetAllExaminationForReview(userId, query.CurrentPage,
                ShowAllExaminationForReviewViewModel.ExaminationsPerPage);

            ViewData["Title"] = "Обратна връзка";

            query.TotalExaminationsCount = queryResult.TotalExaminationsCount;
            query.Examinations = queryResult.Examinations;

            return View(query);
        }
    }
}