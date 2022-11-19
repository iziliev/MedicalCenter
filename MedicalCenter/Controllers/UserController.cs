using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using MedicalCenter.Extensions;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IGlobalService globalService;
        private readonly IRepository repository;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        

        public UserController(
            IUserService _userService,
            IGlobalService _globalService,
            IRepository _repository,
            SignInManager<User> _signInManager,
            UserManager<User> _userManager)
        {
            userService = _userService;
            globalService = _globalService;
            repository = _repository;
            signInManager = _signInManager;
            userManager = _userManager;
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

            if (await userService.IsUsernameExistAsync(registerModel.Username))
            {
                ViewData["Title"] = "Регистрация";
                ModelState.AddModelError("", ModelErrorConstants.UsernameIsTaken);
                registerModel.Genders = await globalService.GetGendersAsync();
                return View(registerModel);
            }

            var result = await userService.Register(registerModel);

            if (result.Succeeded)
            {
                var user = await userService.GetUserByUsernameAsync(registerModel.Username);

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
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            var loginModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

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
                loginModel.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                return View(loginModel);
            }

            if (!await userService.IsUsernameExistAsync(loginModel.Username) && 
                !await userService.IsUserEmailExistAsync(loginModel.Username))
            {
                ViewData["Title"] = "Вход";
                ModelState.AddModelError("", ModelErrorConstants.WrongLogin);
                loginModel.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
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
            loginModel.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { ReturnUrl = returnUrl });

            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var loginModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                TempData["ErrorMessage"] = $"Error from external provider: {remoteError}";
                return View("Login", loginModel);
            }

            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                TempData["ErrorMessage"] = "Error loading external login information.";
                return View("Login", loginModel);
            }

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    var user = await userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        var usernameClaim = info.Principal.FindFirstValue(ClaimTypes.Email);
                        var username = usernameClaim.Substring(0,usernameClaim.IndexOf("@"));

                        var registerExternalViewModel = new RegisterExternalViewModel
                        {
                            Genders = await globalService.GetGendersAsync(),
                            Username = username,
                            Email = email,
                            FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                            LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                            ReturnUrl = returnUrl,
                            LoginProvider = info.LoginProvider
                        };
                        
                        return View("ExternalLoginRegister", registerExternalViewModel);
                    }

                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                TempData["ErrorMessage"] = $"Email claim not received from: {info.LoginProvider}";
                TempData["DangerMessage"] = $"Please contact support on  admin@mc-bg.com";

                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginRegister(RegisterExternalViewModel registerExternalViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                registerExternalViewModel.Genders = await globalService.GetGendersAsync();
                return View(registerExternalViewModel);
            }


            string phoneNumber = registerExternalViewModel.PhoneNumber.Contains('+')
                ? registerExternalViewModel.PhoneNumber
                : $"+359{registerExternalViewModel.PhoneNumber.Remove(0, 1)}";

            var user = new User
            {
                Email = registerExternalViewModel.Email,
                FirstName = registerExternalViewModel.FirstName,
                LastName = registerExternalViewModel.LastName,
                GenderId = registerExternalViewModel.Gender,
                PhoneNumber = phoneNumber,
                UserName = registerExternalViewModel.Username,
                Role = "User",
                JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)
            };

            await userManager.CreateAsync(user);
            await globalService.AddUserRoleAsync(user, RoleConstants.UserRole);
            await globalService.AddClaimAsync(user);
            await signInManager.SignInAsync(user, isPersistent: false);
            
            if (registerExternalViewModel.ReturnUrl == null)
            {
                return RedirectToAction(nameof(Index),"Home");
            }
            return LocalRedirect(registerExternalViewModel.ReturnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.UserRole}")]
        public async Task<IActionResult> Book(string doctorId)
        {

            var model = await userService.FillBookViewModelAsync(doctorId);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.UserRole}")]
        public async Task<IActionResult> Book(BookExaminationViewModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            var date = DateTime.Parse(bookModel.Date);

            if (date == DateTime.Now.Date && TimeSpan.Parse(bookModel.Hour) <= DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1)))
            {
                ModelState.AddModelError("", ModelErrorConstants.WrongHourExaminationError);
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", ModelErrorConstants.WeekendExaminationError);
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            var userId = User.Id();

            var user = await repository.GetByIdAsync<User>(userId);

            if (user == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            var doctor = await userService.GetDoctorByIdAsync(bookModel.DoctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("", ModelErrorConstants.ViewModelError);
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            if (!await userService.IsUserFreeOnDateAnHourAsync(userId, bookModel))
            {
                var examination = await userService.GetExaminationAsync(userId, bookModel);

                ModelState.AddModelError("", $"Вече имате записан час при {examination.DoctorFullName} на {bookModel.Date} от {bookModel.Hour}.");
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            if (!await userService.IsDoctorFreeOnDateAnHourAsync(bookModel))
            {
                ModelState.AddModelError("", $"На {bookModel.Date} часът {bookModel.Hour} е зает.");
                bookModel.WorkHours = await userService.GetDoctorWorkHoursByDoctorIdAsync(bookModel.DoctorId);
                bookModel.HasError = true;
                return View(bookModel);
            }

            await userService.CreateExaminationAsync(user, doctor, bookModel);

            TempData[MessageConstant.SuccessMessage] = $"Успешно е записан час при д-р {doctor.FirstName} {doctor.LastName} - {bookModel.Date} {bookModel.Hour}!";

            return RedirectToAction(nameof(UserExamination));
        }

        [HttpGet]
        public async Task<IActionResult> UserExamination([FromQuery]ShowAllUserExaminationViewModel query)
        {
            var userId = User.Id();

            var queryResult = await userService.GetAllCurrentExaminationAsync(
                userId,
                query.Specialty,
                query.SearchTermDate,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllUserExaminationViewModel.ExaminationsPerPage);

            ViewData["Title"] = "Предстоящи часове за прегледи";

            query.TotalExaminationCount = queryResult.TotalExaminationCount;
            query.Examinations = queryResult.Examinations;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CancelExamination(string examinationId)
        {
            var examination = await repository.GetByIdAsync<Examination>(examinationId);

            TempData[MessageConstant.ErrorMessage] = $"Успешно е изтрит час при {examination.DoctorFullName} - {examination.Date} {examination.Hour}!";

            await userService.CancelUserExaminationAsync(examinationId);

            return RedirectToAction(nameof(UserExamination));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserBoard([FromQuery]ShowAllDoctorUserViewModel query)
        {
            var queryResult = await userService.ShowDoctorOnUserAsync(
                query.Specialty,
                query.SearchTerm,
                query.CurrentPage,
                ShowAllDoctorUserViewModel.DoctorsPerPage);

            ViewData["Title"] = "Запази час";

            query.TotalDoctorsCount = queryResult.TotalDoctorsCount;
            query.Doctors = queryResult.Doctors;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> ExaminationForFeedback([FromQuery]ShowAllExaminationForReviewViewModel query)
        {
            var userId = User.Id();

            var queryResult = await userService.GetAllExaminationForReviewAsync(
                userId, 
                query.Specialty, 
                query.SearchTermDate,
                query.SearchTermName,
                query.CurrentPage,
                ShowAllExaminationForReviewViewModel.ExaminationsPerPage);

            ViewData["Title"] = "Обратна връзка";

            query.TotalExaminationsCount = queryResult.TotalExaminationsCount;
            query.Examinations = queryResult.Examinations;
            query.Specialties = await globalService.GetSpecialtiesAsync();

            return View(query);
        }
    }
}