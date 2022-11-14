using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MedicalCenter.Core.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository repository;
        private readonly IGlobalService globalService;

        public AdministratorService(
            UserManager<User> _userManager,
            IRepository _repository,
            IGlobalService _globalService)
        {
            userManager = _userManager;
            repository = _repository;
            globalService = _globalService;
        }

        public async Task<IdentityResult> CreateDoctorAsync(CreateDoctorViewModel doctorModel)
        {
            string phoneNumber = doctorModel.PhoneNumber.Contains('+')
                ? doctorModel.PhoneNumber
                : $"+359{doctorModel.PhoneNumber.Remove(0, 1)}";

            var doctor = new Doctor()
            {
                Biography = doctorModel.Biography,
                Education = doctorModel.Education,
                Email = doctorModel.Email,
                FirstName = doctorModel.FirstName,
                LastName = doctorModel.LastName,
                GenderId = doctorModel.Gender,
                PhoneNumber = phoneNumber,
                ProfileImageUrl = doctorModel.ProfileImageUrl,
                Representation = doctorModel.Representation,
                SpecialtyId = doctorModel.SpecialtyId,
                UserName = doctorModel.Username,
                Egn = doctorModel.Egn,
                Role = "Doctor",
                JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                SheduleId = doctorModel.SheduleId,
            };

            return await userManager.CreateAsync(doctor, doctorModel.Password);
        }

        public async Task<CreateDoctorViewModel> SearchDoctorAsync(string egn)
        {
            var existDoctor = await repository.All<Doctor>()
                .Where(d => d.Egn == egn)
                .Select(d => new CreateDoctorViewModel
                {
                    Id = d.Id,
                    Username = d.UserName,
                    Biography = d.Biography,
                    Education = d.Education,
                    Egn = d.Egn,
                    Email = d.Email,
                    FirstName = d.FirstName,
                    Gender = d.GenderId,
                    PhoneNumber = d.PhoneNumber,
                    LastName = d.LastName,
                    Representation = d.Representation,
                    SpecialtyId = d.SpecialtyId,
                    ProfileImageUrl = d.ProfileImageUrl,
                    IsOutOfCompany = d.IsOutOfCompany,
                    Role = d.Role,
                    JoinOnDate = d.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                    SheduleId = d.SheduleId
                })
                .FirstOrDefaultAsync();

            return existDoctor;
        }

        public async Task ReturnDoctorAsync(string id)
        {
            var doctor = await repository.All<Doctor>()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            doctor.IsOutOfCompany = false;
            doctor.OutOnDate = null;

            await repository.SaveChangesAsync();
        }

        public async Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(int currentPage = 1, int doctorsPerPage = 5)
        {
            var doctorsQuery = repository.All<Doctor>()
                .Where(d => !d.IsOutOfCompany)
                .Include(s => s.Specialty)
                .OrderBy(x => x.Specialty.Id)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .AsQueryable();

            var doctors = await doctorsQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardDoctorViewModel
                {
                    FirstName = d.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.JoinOnDate,
                    LastName = d.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.PhoneNumber,
                    SpecialityId = d.SpecialtyId,
                    SpecialityName = d.Specialty.Name,
                    Egn = d.Egn
                })
                .ToListAsync();

            return new ShowAllDoctorViewModel
            {
                Doctors = doctors,
                TotalDoctorsCount = doctorsQuery.Count()
            };
        }

        public async Task<Doctor> GetDoctorByEgnAsync(string egn)
        {
            return await repository.All<Doctor>()
                .Where(x => x.Egn == egn)
                .FirstOrDefaultAsync();
        }

        public async Task AddDoctorRoleAsync(Doctor doctor, string doctorRole)
        {
            await userManager.AddToRoleAsync(doctor, doctorRole);
        }

        public async Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(int currentPage = 1, int doctorsPerPage = 5)
        {
            var usersQuery = repository.All<User>()
                .Where(x => x.Role == "User")
                .AsQueryable();

            var users = await usersQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardUserViewModel
                {
                    FirstName = d.FirstName,
                    JoinOnDate = d.JoinOnDate,
                    LastName = d.LastName,
                    PhoneNumber = d.PhoneNumber,
                    Email = d.Email,
                    Username = d.UserName
                })
                .ToListAsync();

            return new ShowAllUserViewModel
            {
                TotalUsersCount = usersQuery.Count(),
                AllUsers = users
            };
        }

        public async Task<MainDoctorViewModel> GetDoctorByIdToEditAsync(string doctorId)
        {
            var doctorById = await repository
                .All<Doctor>()
                .Where(u => u.Id == doctorId)
                .Include(s => s.Specialty)
                .Select(d => new MainDoctorViewModel
                {
                    Education = d.Education,
                    Biography = d.Biography,
                    Email = d.Email,
                    FirstName = d.FirstName,
                    Gender = d.GenderId,
                    Id = d.Id,
                    LastName = d.LastName,
                    PhoneNumber = d.PhoneNumber,
                    ProfileImageUrl = d.ProfileImageUrl,
                    Representation = d.Representation,
                    SpecialtyId = d.SpecialtyId,
                    Username = d.UserName,
                    SpecialityName = d.Specialty.Name,
                    Role = d.Role,
                    IsOutOfCompany = d.IsOutOfCompany,
                    JoinOnDate = d.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                    SheduleId = d.SheduleId,
                })
                .FirstOrDefaultAsync();

            return doctorById;
        }

        public async Task EditDoctorAsync(MainDoctorViewModel doctorModel, Doctor doctor)
        {
            doctor.Email = doctorModel.Email;
            doctor.Education = doctorModel.Education;
            doctor.PhoneNumber = doctorModel.PhoneNumber;
            doctor.LastName = doctorModel.LastName;
            doctor.Biography = doctorModel.Biography;
            doctor.FirstName = doctorModel.FirstName;
            doctor.GenderId = doctorModel.Gender;
            doctor.Id = doctorModel.Id;
            doctor.JoinOnDate = doctorModel.JoinOnDate;
            doctor.Role = doctorModel.Role;
            doctor.IsOutOfCompany = doctorModel.IsOutOfCompany;
            doctor.ProfileImageUrl = doctorModel.ProfileImageUrl;
            doctor.SpecialtyId = doctor.SpecialtyId;
            doctor.Representation = doctorModel.Representation;
            doctor.UserName = doctorModel.Username;
            doctor.OutOnDate = doctorModel.OutOnDate;
            doctor.SheduleId = doctorModel.SheduleId;

            await repository.SaveChangesAsync();
        }


        public async Task DeleteDoctorAsync(string id)
        {
            var doctor = await globalService.GetDoctorByIdAsync(id);
            doctor.OutOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            doctor.IsOutOfCompany = true;
            await repository.SaveChangesAsync();
        }

        public async Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(int currentPage = 1, int doctorsPerPage = 5)
        {
            var doctorsQuery = repository.All<Doctor>()
                .Where(d => d.IsOutOfCompany)
                .Include(s => s.Specialty)
                .OrderBy(x => x.Specialty.Id)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .AsQueryable();

            var doctors = await doctorsQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardDoctorViewModel
                {
                    FirstName = d.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.JoinOnDate,
                    LastName = d.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.PhoneNumber,
                    SpecialityId = d.SpecialtyId,
                    SpecialityName = d.Specialty.Name,
                    Egn = d.Egn
                })
                .ToListAsync();

            return new ShowAllDoctorViewModel
            {
                Doctors = doctors,
                TotalDoctorsCount = doctorsQuery.Count()
            };
        }

        public async Task<DashboardStatisticViewModel> GetStatisticsAsync()
        {
            var bestRatingDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorReviews)
                .OrderByDescending(x => x.DoctorReviews.Average(x => x.Rating))
                .FirstOrDefaultAsync();

            var bestExaminationDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorExaminations)
                .OrderByDescending(x => x.DoctorExaminations.Count)
                .FirstOrDefaultAsync();

            var allDoctorCount = await repository.All<Doctor>()
                .Where(u => !u.IsOutOfCompany)
                .CountAsync();

            var allDoctorOutCount = await repository.All<Doctor>()
                .Where(u => u.IsOutOfCompany)
                .CountAsync();

            var allUser = await repository.All<User>()
                .Where(u => u.Role == nameof(User))
                .CountAsync();

            var allReview = await repository.All<Review>()
                .CountAsync();

            var allExamination = await repository.All<Examination>()
                .Where(e => !e.IsDeleted && e.Date < DateTime.Now)
                .CountAsync();

            var allPastExamination = await repository.All<Examination>()
                .Where(e => !e.IsDeleted && e.Date < DateTime.Now)
                .CountAsync();

            var allFutureExamination = await repository.All<Examination>()
                .Where(e => !e.IsDeleted && e.Date > DateTime.Now)
                .CountAsync();

            return new DashboardStatisticViewModel
            {
                BestRatingDoctorFullName = bestRatingDoctor.DoctorReviews.Count == 0 ? "Няма отзиви" : $"Д-р {bestRatingDoctor.FirstName} {bestRatingDoctor.LastName}",
                BestDoctorRating = bestRatingDoctor.DoctorReviews.Count == 0 ? 0.00 : bestRatingDoctor.DoctorReviews.Average(x => x.Rating),
                BestExaminationDoctorFullName = bestExaminationDoctor.DoctorExaminations.Count == 0 ? "Няма записани часове" : $"Д-р {bestExaminationDoctor.FirstName} {bestExaminationDoctor.LastName}",
                BestExaminationCount = bestExaminationDoctor.DoctorExaminations.Count,
                AllDoctorCount = allDoctorCount,
                AllDoctorOutCount = allDoctorOutCount,
                AllReviews = allReview,
                AllUserCount = allUser,
                AllExamination = allExamination,
                AllFutureExamination = allFutureExamination,
                AllPastExamination = allPastExamination
            };
        }

        public async Task<ShowAllExaminationViewModel> GetAllPastExamination(int currentPage = 1, int examinationsPerPage = 6)
        {
            var examinationQuery = repository.All<Examination>()
                .Where(x => !x.IsDeleted & x.Date < DateTime.Now.Date)
                .Include(u => u.User)
                .Include(d => d.Doctor)
                .ThenInclude(s => s.Specialty)
                .AsQueryable();

            var examinations = await examinationQuery
                .OrderByDescending(x => x.Date < DateTime.Now.Date)
                .Skip((currentPage - 1) * examinationsPerPage)
                .Take(examinationsPerPage)
                .Select(d => new DashboardExaminationViewModel
                {
                    DoctorFullName = d.DoctorFullName,
                    DoctorId = d.DoctorId,
                    PatientFullName = d.UserFullName,
                    PatientId = d.UserId,
                    SpecialityId = d.SpecialityId,
                    SpecialityName = d.Doctor.Specialty.Name,
                    ExaminationDate = d.Date.ToString("dd.MM.yyyy"),
                    ExaminationHour = d.Hour
                })
                .ToListAsync();

            return new ShowAllExaminationViewModel
            {
                AllExamination = examinations,
                CurrentPage = currentPage,
                TotalExaminationCount = examinationQuery.Count()
            };
        }

        public async Task<ShowAllExaminationViewModel> GetAllFutureExamination(int currentPage = 1, int examinationsPerPage = 6)
        {
            var examinationQuery = repository.All<Examination>()
                .Where(x => !x.IsDeleted & x.Date >= DateTime.Today.Date)
                .Include(u => u.User)
                .Include(d => d.Doctor)
                .ThenInclude(s => s.Specialty)
                .AsQueryable();

            var examinations = await examinationQuery
                .OrderByDescending(x => x.Date >= DateTime.Now.Date)
                .Skip((currentPage - 1) * examinationsPerPage)
                .Take(examinationsPerPage)
                .Select(d => new DashboardExaminationViewModel
                {
                    DoctorFullName = d.DoctorFullName,
                    DoctorId = d.DoctorId,
                    PatientFullName = d.UserFullName,
                    PatientId = d.UserId,
                    SpecialityId = d.SpecialityId,
                    SpecialityName = d.Doctor.Specialty.Name,
                    ExaminationDate = d.Date.ToString("dd.MM.yyyy"),
                    ExaminationHour = d.Hour
                })
                .ToListAsync();

            return new ShowAllExaminationViewModel
            {
                AllExamination = examinations,
                CurrentPage = currentPage,
                TotalExaminationCount = examinationQuery.Count()
            };
        }

        public async Task<DashboardStatisticDataViewModel> GetStatisticsDataAsync()
        {
            var examinations = await repository.All<Examination>()
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            var sheduleDictionary = new Dictionary<string, int>()
            {
                {"08:00-12:00",0 },
                {"13:00-17:00",0 }
            };

            foreach (var shedule in examinations)
            {
                if (shedule.SheduleId == 1)
                {
                    sheduleDictionary["08:00-12:00"]++;
                }
                else
                {
                    sheduleDictionary["13:00-17:00"]++;
                }
            }

            var specialitiesDictionary = new Dictionary<string, int>();

            foreach (var speciality in examinations)
            {
                var specialtyName = await repository.AllReadonly<Specialty>()
                    .FirstOrDefaultAsync(x => x.Id == speciality.SpecialityId);

                if (!specialitiesDictionary.ContainsKey(specialtyName.Name))
                {
                    specialitiesDictionary.Add(specialtyName.Name, 0);
                }
                specialitiesDictionary[specialtyName.Name]++;

            }

            var examinationDoctors = await repository.AllReadonly<Examination>()
                .Where(x => !x.IsDeleted)
                .Include(x => x.Doctor)
                .ToListAsync();

            var doctorExaminationDictionary = new Dictionary<string, int>();

            foreach (var examination in examinationDoctors)
            {
                var specialty = await repository.AllReadonly<Specialty>()
                    .FirstOrDefaultAsync(x => x.Id == examination.SpecialityId);

                var doctorName = $"{examination.DoctorFullName}- {specialty.Name}";

                if (!doctorExaminationDictionary.ContainsKey(doctorName))
                {
                    doctorExaminationDictionary[doctorName] = 0;
                }
                doctorExaminationDictionary[doctorName]++;
            }

            var doctorReviews = await repository.AllReadonly<Examination>()
                .Where(x => !x.IsDeleted && x.IsUserReviewedExamination)
                .Include(x => x.Doctor)
                .ThenInclude(r => r.DoctorReviews)
                .ToListAsync();

            var doctorsReview = new Dictionary<string, List<int>>();

            foreach (var doctorReview in doctorReviews)
            {
                var doctorName = $"{doctorReview.DoctorFullName}";
                var review = await repository.AllReadonly<Review>()
                    .FirstOrDefaultAsync(r => r.Id == doctorReview.ReviewId);

                if (!doctorsReview.ContainsKey(doctorName))
                {
                    doctorsReview[doctorName] = new List<int>();
                }
                doctorsReview[doctorName].Add(review.Rating);
            }

            //long sumRating = doctorReviews.Sum(x => x.Review.Rating);
            //long ratingCount = doctorReviews.Select(x=>x.ReviewId).Count();

            return new DashboardStatisticDataViewModel
            {
                Shedules = sheduleDictionary,
                Specialties = specialitiesDictionary,
                DoctorsExaminations = doctorExaminationDictionary,
                DoctorsRating = doctorsReview,
                //CountRaings = ratingCount,
                //SumAllRaings = sumRating
            };
        }
    }
}
