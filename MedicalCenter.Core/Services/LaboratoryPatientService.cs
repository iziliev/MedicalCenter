using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.LaboratoryPatient;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MedicalCenter.Core.Services
{
    public class LaboratoryPatientService : ILaboratoryPatient
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRepository repository;
        private readonly IGlobalService globalService;

        public LaboratoryPatientService(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IRepository _repository,
            IGlobalService _globalService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            repository = _repository;
            globalService = _globalService;
        }

        public async Task<bool> IsEgnExistAsync(string egn)
        {
            return await repository.AllReadonly<LaboratoryPatient>()
                .AnyAsync(p => p.Egn == egn);
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            return await repository.AllReadonly<LaboratoryPatient>()
                .AnyAsync(p => p.UserName == username);
        }

        public async Task<SignInResult> Login(LoginPatientViewModel loginModel)
        {
            var laboratoryParient = await repository.AllReadonly<LaboratoryPatient>()
                .Where(p => p.Egn == loginModel.Egn)
                .FirstOrDefaultAsync();

            if (laboratoryParient == null)
            {
                laboratoryParient = await repository.AllReadonly<LaboratoryPatient>()
                .Where(p => p.UserName == loginModel.Egn)
                .FirstOrDefaultAsync();
            }

            return await signInManager.PasswordSignInAsync(laboratoryParient, loginModel.Password, false, false);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<ShowAllLaboratoryPatientResultViewModel> GetAllResult(
            string userId,
            string? searchTermDate = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var laboratoryPatientQuery = repository.All<Test>()
                .Where(d => d.LaboratoryPatientId == userId)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermDate) == false)
            {
                var searchDate = new DateTime();

                var isDateCorrect = DateTime.TryParseExact(searchTermDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out searchDate);

                if (isDateCorrect)
                {
                    laboratoryPatientQuery = laboratoryPatientQuery
                        .Where(e => e.TestDate.Date == searchDate);
                }
            }

            var results = await laboratoryPatientQuery
                .Skip((currentPage - 1) * laboratoryPatientPerPage)
                .Take(laboratoryPatientPerPage)
                .Select(d => new DashboardLaboratoryPatientResultViewModel
                {
                    Date = d.TestDate.ToString("dd.MM.yyyy"),
                    TestId = d.Id
                })
                .ToListAsync();

            return new ShowAllLaboratoryPatientResultViewModel
            {
                AllResults = results,
                TotalResultCount = laboratoryPatientQuery.Count()
            };
        }

        public async Task<ResultViewModel> GetResultByIdAsync(string id)
        {
            return await repository.AllReadonly<Test>()
                .Include(x=>x.LaboratoryPatient)
                .Where(t => t.Id == id)
                .Select(x=>new ResultViewModel
                {
                    Date = x.TestDate.ToString("dd.MM.yyyy"),
                    PatientName = $"{x.LaboratoryPatient.FirstName} {x.LaboratoryPatient.LastName}",
                    Hct = x.Hct,
                    Hgb = x.Hgb,
                    WBC=x.WBC,
                    UrinepH = x.UrinepH,
                    UrineGravity = x.UrineGravity,
                    RBC = x.RBC,
                    MCH  =x.MCH,
                    MCHC = x.MCHC,
                    MCV = x.MCV,
                    Plt = x.Plt,
                    PatientEgn = x.LaboratoryPatient.Egn,
                    PatientGender = x.LaboratoryPatient.GenderId
                })
                .FirstOrDefaultAsync();
        }
    }
}
