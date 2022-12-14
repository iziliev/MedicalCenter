using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace MedicalCenter.Core.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRepository repository;
        private readonly IGlobalService globalService;

        public UserService(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IRepository _repository,
            IGlobalService _globalService
)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            repository = _repository;
            globalService = _globalService;
        }

        public async Task<bool> IsUserEmailExistAsync(string username)
        {
            return await userManager.FindByEmailAsync(username) != null;
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            return await userManager.FindByNameAsync(username) != null;
        }

        public async Task<SignInResult> Login(LoginViewModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username)
                ?? await userManager.FindByEmailAsync(loginModel.Username);

            if (user.IsOutOfCompany == false)
            {
                //All users without laboratoryPatientCanLogin
                if (user.Role != DataConstants.RoleConstants.LaboratoryUserRole)
                {
                    return await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                }
            }

            //If laboratoryPatient try to login in UserLogin it cant be or ii Admin,Doctor,Laborant is deleted
            return await signInManager.PasswordSignInAsync(user, "*", false, false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerModel)
        {
            string phoneNumber = globalService.ParsePnoneNumber(registerModel.PhoneNumber);
                
            var user = new User
            {
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                GenderId = registerModel.Gender,
                PhoneNumber = phoneNumber,
                UserName = registerModel.Username,
                Role = "User",
                JoinOnDate = globalService.ReturnDateToString(),
            };

            return await userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await repository.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<ShowAllDoctorUserViewModel> ShowDoctorOnUserAsync(
            string? speciality = null, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {

            var doctorsQuery = repository.AllReadonly<Doctor>()
                .Include(u=>u.User)
                .Where(d => !d.User.IsOutOfCompany)
                .Include(s => s.Specialty)
                .OrderBy(x => x.Specialty.Name)
                .ThenBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                doctorsQuery = doctorsQuery
                    .Where(d => EF.Functions.Like(d.Specialty.Name.ToLower(), speciality));
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var searchTermName = searchTerm.ToLower().Split(" ").ToArray();

                if (searchTermName.Length == 2)
                {
                    var firstName = $"%{searchTermName[0]}%";
                    var lastName = $"%{searchTermName[1]}%";

                    doctorsQuery = doctorsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), firstName) || 
                    EF.Functions.Like(d.User.LastName.ToLower(), lastName) || 
                    EF.Functions.Like(d.User.FirstName.ToLower(), lastName) ||
                    EF.Functions.Like(d.User.LastName.ToLower(), firstName));
                }
                else
                {
                    var name = $"%{searchTermName[0]}%";

                    doctorsQuery = doctorsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), name) || EF.Functions.Like(d.User.LastName.ToLower(), name));
                }
            }

            var doctors = await doctorsQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardAllDoctorUserViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    LastName = d.User.LastName,
                    PhoneNumber = d.User.PhoneNumber,
                    SpecialityName = d.Specialty.Name,
                    Email = d.User.Email,
                    ProfileImageUrl = d.ProfileImageUrl,
                    SpecialtyId = d.SpecialtyId,
                })
                .ToListAsync();

            return new ShowAllDoctorUserViewModel
            {
                Doctors = doctors,
                TotalDoctorsCount = doctorsQuery.Count()
            };
        }

        public async Task<IEnumerable<string>> GetDoctorWorkHoursByDoctorIdAsync(string doctorId)
        {
            return await repository.All<Doctor>()
                .Where(d => d.Id == doctorId)
                .Include(s => s.Shedule)
                .ThenInclude(h => h.WorkHours)
                .Select(x => x.Shedule.WorkHours.Select(x => x.Hour))
                .FirstOrDefaultAsync();
        }


        public async Task<Doctor> GetDoctorByIdAsync(string doctorId)
        {
            return await repository.All<Doctor>()
                .Where(d => d.Id == doctorId)
                .Include(s => s.Specialty)
                .Include(u=>u.User)
                .FirstOrDefaultAsync();
        }

        public async Task CreateExaminationAsync(User user, Doctor doctor, BookExaminationViewModel bookModel)
        {
            var examination = new Examination
            {
                DoctorId = bookModel.DoctorId,
                Date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                DoctorFullName = bookModel.DoctorFullName,
                DoctorPhoneNumber = doctor.User.PhoneNumber,
                Hour = bookModel.Hour,
                UserFullName = $"{user.FirstName} {user.LastName}",
                UserId = user.Id,
                UserPhoneNumber = user.PhoneNumber,
                SpecialityId = doctor.SpecialtyId,
                Doctor = doctor,
                User = user,
                Shedule = doctor.Shedule,
                SheduleId = doctor.SheduleId
            };

            user.UserExaminations.Add(examination);
            doctor.DoctorExaminations.Add(examination);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> IsUserFreeOnDateAnHourAsync(string userId, BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.UserId == userId && !e.IsDeleted)
                .Where(d => d.Date == date && d.Hour == bookModel.Hour)
                .FirstOrDefaultAsync() == null;
        }

        public async Task<Examination> GetExaminationAsync(string userId, BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.UserId == userId && !e.IsDeleted)
                .Where(d => d.Date == date && d.Hour == bookModel.Hour)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsDoctorFreeOnDateAnHourAsync(BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.DoctorId == bookModel.DoctorId && !e.IsDeleted)
                .Where(d => d.Date == date && d.Hour == bookModel.Hour)
                .FirstOrDefaultAsync() == null;
        }

        public async Task<string> ReturnDoctorNameByDoctorIdAsync(string doctorId)
        {
            var doctor = await repository.GetByIdAsync<Doctor>(doctorId);

            return $"{doctor.User.FirstName} {doctor.User.LastName}";
        }

        public async Task<ShowAllUserExaminationViewModel> GetAllCurrentExaminationAsync(
            string userId, 
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {

            var examinationQuery = repository.AllReadonly<Examination>()
                .Include(e => e.User)
                .Include(d => d.Doctor)
                .Where(e => e.UserId == userId && e.Date >= DateTime.Today && !e.IsDeleted)
                .OrderBy(x=>x.Date)
                .ThenBy(x=>x.Hour)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                examinationQuery = examinationQuery
                    .Where(s => s.Doctor.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermDate) == false)
            {
                var searchDate = new DateTime();

                var isDateCorrect = DateTime.TryParseExact(searchTermDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out searchDate);

                if (isDateCorrect)
                {
                    examinationQuery = examinationQuery
                    .Where(e => e.Date == searchDate);
                }
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%";

                examinationQuery = examinationQuery
                    .Where(d => EF.Functions.Like(d.DoctorFullName, searchTermName));
            }

            var examinations = await examinationQuery
                .Skip((currentPage - 1) * examinationPerPage)
                .Take(examinationPerPage)
                .Select(e => new DashboardUserExaminationViewModel
                {
                    ExaminationId = e.Id,
                    Date = e.Date.ToString("dd.MM.yyyy"),
                    Hour = e.Hour,
                    DoctorId = e.DoctorId,
                    DoctorFullName = e.DoctorFullName,
                    Specialty = e.Doctor.Specialty.Name,
                    DoctorPhoneNumber = e.DoctorPhoneNumber
                })
                .ToListAsync();

            return new ShowAllUserExaminationViewModel
            {
                Examinations = examinations,
                TotalExaminationCount = examinationQuery.Count(),
            };
        }

        public async Task CancelUserExaminationAsync(string examinationId)
        {
            var examination = await repository.All<Examination>()
                .Where(e => e.Id == examinationId)
                .FirstOrDefaultAsync();

            examination.IsDeleted = true;

            await repository.SaveChangesAsync();
        }

        public async Task<BookExaminationViewModel> FillBookViewModelAsync(string doctorId)
        {
            var doctor = await GetDoctorByIdAsync(doctorId);

            return new BookExaminationViewModel()
            {
                DoctorId = doctorId,
                DoctorFullName = $"Д-р {doctor.User.FirstName} {doctor.User.LastName}",
                WorkHours = await GetDoctorWorkHoursByDoctorIdAsync(doctorId),
                Biography = doctor.Biography,
                Education = doctor.Education,
                ProfileImage = doctor.ProfileImageUrl,
                Representation = doctor.Representation,
                SpecialityName = doctor.Specialty.Name
            };
        }

        public async Task<ShowAllExaminationForReviewViewModel> GetAllExaminationForReviewAsync(
            string userId, 
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var examinationQuery = repository.All<Examination>()
                .Include(d => d.Doctor)
                .Where(e => e.UserId == userId && !e.IsDeleted && e.Date < DateTime.Today && !e.IsUserReviewedExamination)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                examinationQuery = examinationQuery
                    .Where(d => d.Doctor.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermDate) == false)
            {
                var searchDate = new DateTime();

                var isDateCorrect = DateTime.TryParseExact(searchTermDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out searchDate);

                if (isDateCorrect)
                {
                    examinationQuery = examinationQuery
                        .Where(e => e.Date == searchDate);
                }
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%";

                examinationQuery = examinationQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName, searchTermName) || EF.Functions.Like(d.User.LastName, searchTermName));
            }

            var examinations = await examinationQuery
                .Skip((currentPage - 1) * examinationPerPage)
                .Take(examinationPerPage)
                .Select(e => new DashboardExaminationForReviewViewModel
                {
                    DoctorId = e.DoctorId,
                    ExaminationId = e.Id,
                    DoctorNameAndSpecialty = $"{e.DoctorFullName} ({e.Doctor.Specialty.Name})",
                    DateAndHour = $"{e.Date:dd.MM.yyyy} {e.Hour}",
                    IsReviewed = e.IsUserReviewedExamination
                })
                .ToListAsync();

            return new ShowAllExaminationForReviewViewModel
            {
                Examinations = examinations,
                TotalExaminationsCount = examinationQuery.Count()
            };
        }
    }
}