using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Areas.Contracts;
using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MedicalCenter.Areas.Administrator.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository repository;
        private readonly IGlobalService globalService;
        private readonly SignInManager<User> signInManager;

        public AdministratorService(
            UserManager<User> _userManager,
            IRepository _repository,
            IGlobalService _globalService,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            repository = _repository;
            globalService = _globalService;
            signInManager = _signInManager;
        }


        public async Task<IdentityResult> CreateUserAsync<T>(T userModel)
            where T : class
        {
            if (typeof(T).Equals(typeof(CreateDoctorViewModel))) 
            {
                var doctorModel = userModel as CreateDoctorViewModel;

                string phoneNumber = globalService.ParsePnoneNumber(doctorModel.PhoneNumber);

                var doctor = new Doctor()
                {
                    Biography = doctorModel.Biography,
                    Education = doctorModel.Education,
                    ProfileImageUrl = doctorModel.ProfileImageUrl,
                    Representation = doctorModel.Representation,
                    SpecialtyId = doctorModel.SpecialtyId,
                    Egn = doctorModel.Egn,
                    SheduleId = doctorModel.SheduleId
                };

                var user = new User
                {
                    Email = doctorModel.Email,
                    FirstName = doctorModel.FirstName,
                    LastName = doctorModel.LastName,
                    GenderId = doctorModel.Gender,
                    PhoneNumber = phoneNumber,
                    UserName = doctorModel.Username,
                    Role = "Doctor",
                    JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Doctor = doctor,
                    DoctorId = doctor.Id
                };

                return await userManager.CreateAsync(user, doctorModel.Password);
            }
            else if (typeof(T).Equals(typeof(CreateLaborantViewModel))) 
            {
                var laborantModel = userModel as CreateLaborantViewModel;

                string phoneNumber = globalService.ParsePnoneNumber(laborantModel.PhoneNumber);

                var laborant = new Laborant()
                {
                    Egn = laborantModel.Egn
                };

                var user = new User
                {
                    Email = laborantModel.Email,
                    FirstName = laborantModel.FirstName,
                    LastName = laborantModel.LastName,
                    GenderId = laborantModel.Gender,
                    PhoneNumber = phoneNumber,
                    UserName = laborantModel.Username,
                    Role = "Laborant",
                    JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Laborant = laborant,
                    LaborantId = laborant.Id
                };

                return await userManager.CreateAsync(user, laborantModel.Password);
            }
            else
            {
                var adminModel = userModel as CreateAdminViewModel;

                string phoneNumber = globalService.ParsePnoneNumber(adminModel.PhoneNumber);

                var administrator = new Infrastructure.Data.Models.Administrator()
                {
                    Egn = adminModel.Egn
                };

                var user = new User
                {
                    Email = adminModel.Email,
                    FirstName = adminModel.FirstName,
                    LastName = adminModel.LastName,
                    GenderId = adminModel.Gender,
                    PhoneNumber = phoneNumber,
                    UserName = adminModel.Username,
                    Role = "Administrator",
                    JoinOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Administrator = administrator,
                    AdministratorId = administrator.Id
                };

                return await userManager.CreateAsync(user, adminModel.Password);
            }
        }

        public async Task<T> SearchUserByEgnAsync<T, Z>(string egn)
            where T : class
            where Z : class
        {
            if (typeof(Z).Equals(typeof(Laborant)))
            {
                var existLaborant = await repository.All<Laborant>()
                .Where(d => d.Egn == egn)
                .Include(u => u.User)
                .Select(d => new CreateLaborantViewModel
                {
                    Id = d.Id,
                    Username = d.User.UserName,
                    Egn = d.Egn,
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    PhoneNumber = d.User.PhoneNumber,
                    LastName = d.User.LastName,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(existLaborant, typeof(T));
            }
            else if (typeof(T).Equals(typeof(Doctor)))
            {
                var existDoctor = await repository.All<Doctor>()
                .Where(d => d.Egn == egn)
                .Include(d => d.User)
                .Select(d => new CreateDoctorViewModel
                {
                    Id = d.Id,
                    Username = d.User.UserName,
                    Biography = d.Biography,
                    Education = d.Education,
                    Egn = d.Egn,
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    PhoneNumber = d.User.PhoneNumber,
                    LastName = d.User.LastName,
                    Representation = d.Representation,
                    SpecialtyId = d.SpecialtyId,
                    ProfileImageUrl = d.ProfileImageUrl,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                    SheduleId = d.SheduleId
                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(existDoctor, typeof(T));
            }
            else
            {
                var existAdmin = await repository.All<Infrastructure.Data.Models.Administrator>()
                .Where(d => d.Egn == egn)
                .Include(d => d.User)
                .Select(d => new CreateAdminViewModel
                {
                    Id = d.Id,
                    Username = d.User.UserName,
                    Egn = d.Egn,
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    PhoneNumber = d.User.PhoneNumber,
                    LastName = d.User.LastName,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,

                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(existAdmin, typeof(T));
            }
        }

        public async Task<Infrastructure.Data.Models.Administrator> GetAdminByUserIdAsync(string id)
        {
            return await repository.All<Infrastructure.Data.Models.Administrator>()
                .Include(a => a.User)
                .Where(a => a.User.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<T> GetUserByIdAsync<T>(string id)
            where T : class
        {
            if (typeof(T).Equals(typeof(Doctor)))
            {
                var doctor =  await repository.All<Doctor>()
                .Where(u => u.Id == id)
                .Include(d => d.User)
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(doctor, typeof(T));
            }
            else if (typeof(T).Equals(typeof(Laborant)))
            {
                var laborant =  await repository.All<Laborant>()
                .Where(u => u.Id == id)
                .Include(d => d.User)
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(laborant, typeof(T));
            }
            else
            {
                var admin = await repository.All<Infrastructure.Data.Models.Administrator>()
                .Where(u => u.Id == id)
                .Include(d => d.User)
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(admin, typeof(T));
            }
        }

        public async Task ReturnAsync<T>(string id)
            where T : class
        {
            if (typeof(T).Equals(typeof(Doctor)))
            {
                var user = await repository.All<User>()
                    .Where(u => u.DoctorId == id)
                    .FirstOrDefaultAsync();

                user.IsOutOfCompany = false;
                user.Doctor.OutOnDate = null;
            }
            else if(typeof(T).Equals(typeof(Laborant)))
            {
                var user = await repository.All<User>()
                    .Where(u => u.LaborantId == id)
                    .FirstOrDefaultAsync();
                user.IsOutOfCompany = false;
                user.Laborant.OutOnDate = null;
            }
            else
            {
                var user = await repository.All<User>()
                    .Where(u => u.AdministratorId == id)
                    .FirstOrDefaultAsync();
                user.IsOutOfCompany = false;
                user.Administrator.OutOnDate = null;
            }
            await repository.SaveChangesAsync();
        }

        public async Task<ShowAllAdminViewModel> GetAllCurrentAdminAsync(
            string id,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var adminsQuery = repository.All<Infrastructure.Data.Models.Administrator>()
                .Include(d => d.User)
                .Where(d => !d.User.IsOutOfCompany && d.User.Id != id)
                .OrderBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                adminsQuery = adminsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                adminsQuery = adminsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var admins = await adminsQuery
                .Skip((currentPage - 1) * adminsPerPage)
                .Take(adminsPerPage)
                .Select(d => new DashboardAdminViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
                    Egn = d.Egn,
                    Email = d.User.Email
                })
                .ToListAsync();

            return new ShowAllAdminViewModel
            {
                Admins = admins,
                TotalAdminsCount = adminsQuery.Count()
            };
        }

        public async Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(
            string? speciality = null,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var doctorsQuery = repository.All<Doctor>()
                .Include(d => d.User)
                .Where(d => !d.User.IsOutOfCompany)
                .Include(d => d.User)
                .Include(s => s.Specialty)
                .OrderBy(x => x.Specialty.Id)
                .ThenBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                doctorsQuery = doctorsQuery
                    .Where(d => d.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                doctorsQuery = doctorsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                doctorsQuery = doctorsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var doctors = await doctorsQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardDoctorViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
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

        public async Task<T> GetByEgnAsync<T>(string egn)
            where T : class
        {
            if (typeof(T).Equals(typeof(Doctor)))
            {
                var doctor = await repository.All<Doctor>()
                    .Include(d => d.User)
                    .Where(x => x.Egn == egn)
                    .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(doctor, typeof(T));
            }
            else if(typeof(T).Equals(typeof(Laborant)))
            {
                var laborant = await repository.All<Laborant>()
                    .Include(d => d.User)
                    .Where(x => x.Egn == egn)
                    .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(laborant, typeof(T));
            }
            else
            {
                var administrator = await repository.All<Infrastructure.Data.Models.Administrator>()
                    .Include(d => d.User)
                    .Where(x => x.Egn == egn)
                    .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(administrator, typeof(T));
            }
        }

        public async Task AddRoleAsync(User user, string roleName)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(
            string? searchTermEmail = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var usersQuery = repository.All<User>()
                .Where(x => x.Role == "User")
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEmail) == false)
            {
                searchTermEmail = $"%{searchTermEmail}%".ToLower();

                usersQuery = usersQuery
                    .Where(d => EF.Functions.Like(d.Email.ToLower(), searchTermEmail));
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                usersQuery = usersQuery
                    .Where(d => EF.Functions.Like(d.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.LastName.ToLower(), searchTermName));
            }

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

        public async Task<T> GetUserByIdToEditAsync<T, Z>(string id)
            where T : class
            where Z : class
        {
            if (typeof(Z).Equals(typeof(Doctor)))
            {
                var doctor = await repository
                .All<Doctor>()
                .Where(u => u.Id == id)
                .Include(U => U.User)
                .Include(s => s.Specialty)
                .Select(d => new MainDoctorViewModel
                {
                    Education = d.Education,
                    Biography = d.Biography,
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    Id = d.Id,
                    LastName = d.User.LastName,
                    PhoneNumber = d.User.PhoneNumber,
                    ProfileImageUrl = d.ProfileImageUrl,
                    Representation = d.Representation,
                    SpecialtyId = d.SpecialtyId,
                    Username = d.User.UserName,
                    SpecialityName = d.Specialty.Name,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                    SheduleId = d.SheduleId,
                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(doctor, typeof(T));
            }
            else if (typeof(Z).Equals(typeof(Laborant)))
            {
                var laborant = await repository
                .All<Laborant>()
                .Where(u => u.Id == id)
                .Include(u => u.User)
                .Select(d => new MainLaborantViewModel
                {
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    Id = d.Id,
                    LastName = d.User.LastName,
                    PhoneNumber = d.User.PhoneNumber,
                    Username = d.User.UserName,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(laborant, typeof(T));
            }
            else
            {
                var admin = await repository
                .All<Infrastructure.Data.Models.Administrator>()
                .Where(u => u.Id == id)
                .Include(U => U.User)
                .Select(d => new MainAdminViewModel
                {
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    Id = d.Id,
                    LastName = d.User.LastName,
                    PhoneNumber = d.User.PhoneNumber,
                    Username = d.User.UserName,
                    Role = d.User.Role,
                    JoinOnDate = d.User.JoinOnDate,
                    OutOnDate = d.OutOnDate,
                })
                .FirstOrDefaultAsync();

                return (T)Convert.ChangeType(admin, typeof(T));

            }
        }

        public async Task EditUserAsync<T,Z>(T userModel, Z user)
            where T : class
            where Z : class
        {
            if (typeof(Z).Equals(typeof(Doctor)))
            {
                var doctorModel = userModel as MainDoctorViewModel;
                var doctor = user as Doctor;

                doctor.User.Email = doctorModel.Email;
                doctor.Education = doctorModel.Education;
                doctor.User.PhoneNumber = doctorModel.PhoneNumber;
                doctor.User.LastName = doctorModel.LastName;
                doctor.Biography = doctorModel.Biography;
                doctor.User.FirstName = doctorModel.FirstName;
                doctor.User.GenderId = doctorModel.Gender;
                doctor.Id = doctorModel.Id;
                doctor.User.JoinOnDate = doctorModel.JoinOnDate;
                doctor.User.Role = doctorModel.Role;
                doctor.ProfileImageUrl = doctorModel.ProfileImageUrl;
                doctor.SpecialtyId = doctor.SpecialtyId;
                doctor.Representation = doctorModel.Representation;
                doctor.User.UserName = doctorModel.Username;
                doctor.OutOnDate = doctorModel.OutOnDate;
                doctor.SheduleId = doctorModel.SheduleId;

                await repository.SaveChangesAsync();
            }
            else if (typeof(Z).Equals(typeof(Laborant)))
            {
                var laborantModel = userModel as MainLaborantViewModel;
                var laborant = user as Laborant;

                laborant.User.Email = laborantModel.Email;
                laborant.User.PhoneNumber = laborantModel.PhoneNumber;
                laborant.User.LastName = laborantModel.LastName;
                laborant.User.FirstName = laborantModel.FirstName;
                laborant.User.GenderId = laborantModel.Gender;
                laborant.Id = laborantModel.Id;
                laborant.User.JoinOnDate = laborantModel.JoinOnDate;
                laborant.User.Role = laborantModel.Role;
                laborant.User.UserName = laborantModel.Username;
                laborant.OutOnDate = laborantModel.OutOnDate;

                await repository.SaveChangesAsync();
            }
            else
            {
                var adminModel = userModel as MainAdminViewModel;
                var admin = user as Infrastructure.Data.Models.Administrator;

                admin.User.Email = adminModel.Email;
                admin.User.PhoneNumber = adminModel.PhoneNumber;
                admin.User.LastName = adminModel.LastName;
                admin.User.FirstName = adminModel.FirstName;
                admin.User.GenderId = adminModel.Gender;
                admin.Id = adminModel.Id;
                admin.User.JoinOnDate = adminModel.JoinOnDate;
                admin.User.Role = adminModel.Role;
                admin.User.UserName = adminModel.Username;
                admin.OutOnDate = adminModel.OutOnDate;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync<T>(string id)
            where T : class
        {
            if (typeof(T).Equals(typeof(Doctor)))
            {
                var doctor = await repository.All<Doctor>()
                    .Where(x => x.User.DoctorId == id)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                doctor.OutOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                doctor.User.IsOutOfCompany = true;
                await repository.SaveChangesAsync();
            }
            else if(typeof(T).Equals(typeof(Laborant)))
            {
                var laborant = await repository.All<Laborant>()
                    .Where(x => x.User.LaborantId == id)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                laborant.OutOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                laborant.User.IsOutOfCompany = true;
                await repository.SaveChangesAsync();
            }
            else
            {
                var administrator = await repository.All<Infrastructure.Data.Models.Administrator>()
                    .Where(x => x.User.AdministratorId == id)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                administrator.OutOnDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                administrator.User.IsOutOfCompany = true;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<ShowAllAdminViewModel> GetAllLeftAdminAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var adminsQuery = repository.All<Infrastructure.Data.Models.Administrator>()
                .Include(u=>u.User)
                .Where(d => d.User.IsOutOfCompany)
                .OrderBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                adminsQuery = adminsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                adminsQuery = adminsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var admins = await adminsQuery
                .Skip((currentPage - 1) * adminsPerPage)
                .Take(adminsPerPage)
                .Select(d => new DashboardAdminViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
                    Egn = d.Egn,
                    Email = d.User.Email
                })
                .ToListAsync();

            return new ShowAllAdminViewModel
            {
                Admins = admins,
                TotalAdminsCount = adminsQuery.Count()
            };
        }


        public async Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(
            string? speciality = null,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var doctorsQuery = repository.All<Doctor>()
                .Include(u=>u.User)
                .Where(d => d.User.IsOutOfCompany)
                .Include(s => s.Specialty)
                .OrderBy(x => x.Specialty.Id)
                .ThenBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(speciality) == false)
            {
                doctorsQuery = doctorsQuery
                    .Where(d => d.Specialty.Name == speciality);
            }

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                doctorsQuery = doctorsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                doctorsQuery = doctorsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var doctors = await doctorsQuery
                .Skip((currentPage - 1) * doctorsPerPage)
                .Take(doctorsPerPage)
                .Select(d => new DashboardDoctorViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
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

        public async Task<ShowAllExaminationViewModel> GetAllPastExamination(
            string? speciality = null,
            string? searchTermDate = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int examinationsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var examinationQuery = repository.All<Examination>()
                .Where(x => !x.IsDeleted & x.Date < DateTime.Now.Date)
                .Include(u => u.User)
                .Include(d => d.Doctor)
                .ThenInclude(s => s.Specialty)
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
                searchTermName = $"%{searchTermName}%".ToLower();

                examinationQuery = examinationQuery
                    .Where(d => EF.Functions.Like(d.Doctor.User.FirstName, searchTermName) || EF.Functions.Like(d.Doctor.User.LastName, searchTermName));
            }

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

        public async Task<ShowAllExaminationViewModel> GetAllFutureExamination(
            string? speciality = null,
            string? searchTermDate = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int examinationsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var examinationQuery = repository.All<Examination>()
                .Where(x => !x.IsDeleted & x.Date >= DateTime.Today.Date)
                .Include(u => u.User)
                .Include(d => d.Doctor)
                .ThenInclude(s => s.Specialty)
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
                searchTermName = $"%{searchTermName}%".ToLower();

                examinationQuery = examinationQuery
                    .Where(d => EF.Functions.Like(d.Doctor.User.FirstName, searchTermName) || EF.Functions.Like(d.Doctor.User.LastName, searchTermName));
            }

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

        public async Task<T> GetStatisticsAsync<T>()
            where T : class
        {
            if (typeof(T).Equals(typeof(DashboardStatisticDataViewModel)))
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

                var top5Specialises = specialitiesDictionary
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value)
                    .Take(5);

                var examinationDoctors = await repository.AllReadonly<Examination>()
                    .Where(x => !x.IsDeleted)
                    .Include(x => x.Doctor)
                    .ToListAsync();

                var doctorExaminationDictionary = new Dictionary<string, int>();

                foreach (var examination in examinationDoctors)
                {
                    var specialty = await repository.AllReadonly<Specialty>()
                        .FirstOrDefaultAsync(x => x.Id == examination.SpecialityId);

                    var doctorName = $"{examination.DoctorFullName} ({specialty.Name})";

                    if (!doctorExaminationDictionary.ContainsKey(doctorName))
                    {
                        doctorExaminationDictionary[doctorName] = 0;
                    }
                    doctorExaminationDictionary[doctorName]++;
                }

                var top5DoctorExamination = doctorExaminationDictionary
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value)
                    .Take(5);

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

                var sumRatingValue = new Dictionary<int, int>()
            {
                {1, 0},{2, 0},{3, 0},{4, 0},{5, 0}
            };

                var allReviews = await repository.AllReadonly<Review>()
                    .Where(x => x.Id != null)
                    .ToListAsync();

                long sumRating = 0;
                long countRating = allReviews.Count;


                foreach (var review in allReviews)
                {
                    sumRatingValue[review.Rating]++;
                    sumRating += review.Rating;
                }

                var dataStatistic = new DashboardStatisticDataViewModel
                {
                    Shedules = sheduleDictionary,
                    Specialties = specialitiesDictionary,
                    Top5Specialises = top5Specialises,
                    DoctorsExaminations = doctorExaminationDictionary,
                    Top5DoctorExamination = top5DoctorExamination,
                    DoctorsRating = doctorsReview,
                    CountRaings = countRating,
                    SumAllRaings = sumRating
                };

                return (T)Convert.ChangeType(dataStatistic, typeof(T));
            }
            else if (typeof(T).Equals(typeof(DashboardStatisticLabViewModel)))
            {
                var allLaborantCount = await repository.All<Laborant>()
                .Include(u => u.User)
                .Where(u => !u.User.IsOutOfCompany)
                .CountAsync();

                var allLaborantOutCount = await repository.All<Laborant>()
                    .Include(u => u.User)
                    .Where(u => u.User.IsOutOfCompany)
                    .CountAsync();

                var allTestCount = await repository.All<Test>()
                    .CountAsync();

                var laborantStatistic = new DashboardStatisticLabViewModel
                {
                    AllLaborantCount = allLaborantCount,
                    AllLaborantOutCount = allLaborantOutCount,
                    AllTestCount = allTestCount
                };

                return (T)Convert.ChangeType(laborantStatistic, typeof(T));
            }
            else if (typeof(T).Equals(typeof(DashboardStatisticViewModel)))
            {
                var bestRatingDoctor = await repository.All<Doctor>()
                .Include(d => d.DoctorReviews)
                .Include(d => d.User).Include(d => d.User)
                .OrderByDescending(x => x.DoctorReviews.Average(x => x.Rating))
                .FirstOrDefaultAsync();

                var bestExaminationDoctor = await repository.All<Doctor>()
                    .Include(d => d.DoctorExaminations)
                    .Include(d => d.User)
                    .OrderByDescending(x => x.DoctorExaminations.Count)
                    .FirstOrDefaultAsync();

                var allDoctorCount = await repository.All<Doctor>()
                    .Include(u => u.User)
                    .Where(u => !u.User.IsOutOfCompany)
                    .CountAsync();

                var allDoctorOutCount = await repository.All<Doctor>()
                    .Include(u => u.User)
                    .Where(u => u.User.IsOutOfCompany)
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

                var statistic = new DashboardStatisticViewModel
                {
                    BestRatingDoctorFullName = bestRatingDoctor.DoctorReviews.Count == 0 ? "Няма отзиви" : $"Д-р {bestRatingDoctor.User.FirstName} {bestRatingDoctor.User.LastName}",
                    BestDoctorRating = bestRatingDoctor.DoctorReviews.Count == 0 ? "0.00" : bestRatingDoctor.DoctorReviews.Average(x => x.Rating).ToString("F2"),
                    BestExaminationDoctorFullName = bestExaminationDoctor.DoctorExaminations.Count == 0 ? "Няма записани часове" : $"Д-р {bestExaminationDoctor.User.FirstName} {bestExaminationDoctor.User.LastName}",
                    BestExaminationCount = bestExaminationDoctor.DoctorExaminations.Count,
                    AllDoctorCount = allDoctorCount,
                    AllDoctorOutCount = allDoctorOutCount,
                    AllReviews = allReview,
                    AllUserCount = allUser,
                    AllExamination = allExamination,
                    AllFutureExamination = allFutureExamination,
                    AllPastExamination = allPastExamination
                };

                return (T)Convert.ChangeType(statistic, typeof(T));
            }
            else
            {
                var allAdminCount = await repository.All<Infrastructure.Data.Models.Administrator>()
                .Include(u => u.User)
                .Where(u => !u.User.IsOutOfCompany)
                .CountAsync();

                var allAdminOutCount = await repository.All<Infrastructure.Data.Models.Administrator>()
                    .Include(u => u.User)
                    .Where(u => u.User.IsOutOfCompany)
                    .CountAsync();

                
                var adminStatistic = new DashboardStatisticAdminViewModel
                {
                    AllAdministratorCount = allAdminCount,
                    AllAdministratorOutCount = allAdminOutCount,
                };

                return (T)Convert.ChangeType(adminStatistic, typeof(T));
            }
        }

        public async Task<ShowAllLaborantViewModel> GetAllLeftLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var laborantsQuery = repository.All<Laborant>()
                .Include(u => u.User)
                .Where(d => d.User.IsOutOfCompany)
                .Include(u => u.User)
                .OrderBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                laborantsQuery = laborantsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                laborantsQuery = laborantsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var doctors = await laborantsQuery
                .Skip((currentPage - 1) * laborantsPerPage)
                .Take(laborantsPerPage)
                .Select(d => new DashboardLaborantViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
                    Egn = d.Egn
                })
                .ToListAsync();

            return new ShowAllLaborantViewModel
            {
                Laborants = doctors,
                TotalLaborantsCount = laborantsQuery.Count()
            };
        }

        public async Task<ShowAllLaborantViewModel> GetAllCurrentLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantsPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var laborantsQuery = repository.All<Laborant>()
                .Include(u => u.User)
                .Where(d => !d.User.IsOutOfCompany)
                .Include(u => u.User)
                .OrderBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                laborantsQuery = laborantsQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                laborantsQuery = laborantsQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var doctors = await laborantsQuery
                .Skip((currentPage - 1) * laborantsPerPage)
                .Take(laborantsPerPage)
                .Select(d => new DashboardLaborantViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    OutOnDate = d.OutOnDate,
                    PhoneNumber = d.User.PhoneNumber,
                    Egn = d.Egn
                })
                .ToListAsync();

            return new ShowAllLaborantViewModel
            {
                Laborants = doctors,
                TotalLaborantsCount = laborantsQuery.Count()
            };
        }

        public async Task<IEnumerable<Specialty>> GetSpecialtiesAsync()
        {
            return await repository.All<Specialty>().ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await repository.All<Gender>().ToListAsync();
        }

        public async Task<IEnumerable<Shedule>> GetShedulesAsync()
        {
            return await repository.All<Shedule>().ToListAsync();
        }

        public async Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel)
        {
            doctorEditModel.Genders = await GetGendersAsync();
            doctorEditModel.Specialties = await GetSpecialtiesAsync();
            doctorEditModel.Shedules = await GetShedulesAsync();

            return doctorEditModel;
        }

        public async Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel)
        {
            doctorCreateModel.Genders = await GetGendersAsync();
            doctorCreateModel.Specialties = await GetSpecialtiesAsync();
            doctorCreateModel.Shedules = await GetShedulesAsync();

            return doctorCreateModel;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
