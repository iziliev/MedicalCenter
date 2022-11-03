using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MedicalCenter.Core.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRepository repository;

        public UserService(UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IRepository _repository)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            repository = _repository;
        }

        public async Task<bool> IsEmailExist(string username)
        {
            return await userManager.FindByEmailAsync(username) == null ? false : true;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await userManager.FindByNameAsync(username) == null ? false : true;
        }

        public async Task<SignInResult> Login(LoginViewModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username) == null ? await userManager.FindByEmailAsync(loginModel.Username) : await userManager.FindByNameAsync(loginModel.Username);

            return await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerModel)
        {
            string phoneNumber = registerModel.PhoneNumber.Contains('+') ? registerModel.PhoneNumber : $"+359{registerModel.PhoneNumber.Remove(0,1)}";

            var user = new User
            {
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                GenderId = registerModel.Gender,
                PhoneNumber = phoneNumber,
                UserName = registerModel.Username,
                Role = "User",
                JoinOnDate = DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)
            };

            return await userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await repository.All<User>().FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<AllDoctorUserViewModel>> ShowDoctorOnUser()
        {
            return await repository
                .All<Doctor>()
                .Include(s => s.Specialty)
                .Select(d => new AllDoctorUserViewModel
                {
                    Email = d.Email,
                    FirstName = d.FirstName,
                    Id = d.Id,
                    LastName = d.LastName,
                    PhoneNumber = d.PhoneNumber,
                    ProfileImageUrl = d.ProfileImageUrl,
                    SpecialtyId = d.SpecialtyId,
                    SpecialityName = d.Specialty.Name,
                })
                .OrderBy(s=>s.SpecialityName)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetWorkHoursByDoctorId(string doctorId)
        {
            return await repository.All<Doctor>()
                .Where(d => d.Id == doctorId)
                .Include(s => s.Shedule)
                .ThenInclude(h => h.WorkHours)
                .Select(x => x.Shedule.WorkHours.Select(x => x.Hour))
                .FirstOrDefaultAsync();               
        }


        public async Task<Doctor> GetDoctorById(string doctorId)
        {
            return await repository.All<Doctor>()
                .Include(s=>s.Specialty)
                .Where(d => d.Id == doctorId).FirstOrDefaultAsync();
        }

        public async Task CreateExamination(User user, Doctor doctor, BookExaminationViewModel bookModel)
        {
            var examination = new Examination
            {
                DoctorId = bookModel.DoctorId,
                Date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy",CultureInfo.InvariantCulture),
                DoctorFullName = bookModel.DoctorFullName,
                DoctorPhoneNumber = doctor.PhoneNumber,
                Hour = bookModel.Hour,
                UserFullName = $"{user.FirstName} {user.LastName}",
                UserId = user.Id,
                UserPhoneNumber = user.PhoneNumber,
                SpecialityId = doctor.SpecialtyId,
                Doctor=doctor,
                User=user
            };

            user.UserExaminations.Add(examination);
            doctor.DoctorExaminations.Add(examination);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> IsUserFreeOnDateAnHour(string userId, BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.UserId == userId)
                .Where(d=>d.Date == date && d.Hour==bookModel.Hour)
                .FirstOrDefaultAsync() == null ? true : false;
        }

        public async Task<Examination> GetExaminationAsync (string userId, BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.UserId == userId)
                .Where(d => d.Date == date && d.Hour == bookModel.Hour)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsDoctorFreeOnDateAnHour(BookExaminationViewModel bookModel)
        {
            var date = DateTime.ParseExact(bookModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return await repository.All<Examination>()
                .Where(e => e.DoctorId == bookModel.DoctorId)
                .Where(d => d.Date == date && d.Hour == bookModel.Hour)
                .FirstOrDefaultAsync() == null ? true : false;
        }

        public async Task<string> ReturnDoctorName(string doctorId)
        {
            var doctor = await GetDoctorById(doctorId);

            return $"{doctor.FirstName} {doctor.LastName}";
        }

        public async Task<IEnumerable<UserExaminationViewModel>> GetAllCurrentExamination(string userId)
        {
            return await repository.All<Examination>()
                .Include(e => e.User)
                .Include(d=>d.Doctor)
                .Where(e=>e.UserId == userId && e.Date>= DateTime.Today && !e.IsDeleted)
                .Select(e => new UserExaminationViewModel
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
        }

        public async Task CancelUserExamination(string examinationId)
        {
            var examination = await repository.All<Examination>()
                .Where(e => e.Id == examinationId).FirstOrDefaultAsync();
            
            examination.IsDeleted = true;

            await repository.SaveChangesAsync();
        }

        public async Task<BookExaminationViewModel> FillBookViewModel(string doctorId)
        {
            var doctor = await GetDoctorById(doctorId);

            return new BookExaminationViewModel()
            {
                DoctorId = doctorId,
                DoctorFullName = $"Д-р {doctor.FirstName} {doctor.LastName}",
                WorkHours = await GetWorkHoursByDoctorId(doctorId),
                Biography=doctor.Biography,
                Education=doctor.Education,
                ProfileImage=doctor.ProfileImageUrl,
                Representation=doctor.Representation,
                SpecialityName = doctor.Specialty.Name
            };
        }

        public async Task<IEnumerable<ExaminationForReviewViewModel>> GetAllExaminationForReview(string userId)
        {
            return await repository.All<Examination>()
                .Include(d => d.Doctor)
                .Where(e => e.UserId == userId && !e.IsDeleted && e.Date < DateTime.Today && !e.IsUserReviewedExamination)
                .Select(e => new ExaminationForReviewViewModel
                {
                    DoctorId = e.DoctorId,
                    ExaminationId = e.Id,
                    DoctorNameAndSpecialty = $"{e.DoctorFullName} ({e.Doctor.Specialty.Name})",
                    DateAndHour = $"{e.Date.ToString("dd.MM.yyyy")} {e.Hour}"
                })
                .ToListAsync();
        }
    }
}