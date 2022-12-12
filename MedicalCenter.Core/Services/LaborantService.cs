using MedicalCenter.Core.Contracts;
using MedicalCenter.Core.Models.Laborant;
using MedicalCenter.Infrastructure.Data.Common;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Core.Services
{
    public class LaborantService : ILaborantService
    {
        private readonly IGlobalService globalService;
        private readonly UserManager<User> userManager;
        private readonly IRepository repository;

        public LaborantService(
            IGlobalService _globalService,
            UserManager<User> _userManager,
            IRepository _repository)
        {
            globalService = _globalService;
            userManager = _userManager;
            repository = _repository;
        }

        public async Task AddLaboratoryPatientRoleAsync(User laboratoryPatient, string laboratoryPatientRole)
        {
            await userManager.AddToRoleAsync(laboratoryPatient, laboratoryPatientRole);
        }

        public async Task<LaboratoryPatient> GetLaboratoryPatientByEgnAsync(string egn)
        {
            return await repository.All<LaboratoryPatient>()
                .Where(x => x.Egn == egn)
                .FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> CreateLaboratoryPatientAsync(CreateLaboratoryPatientViewModel laboratoryPatientModel)
        {
            string phoneNumber = globalService.ParsePnoneNumber(laboratoryPatientModel.PhoneNumber);

            var user = new User
            {
                FirstName = laboratoryPatientModel.FirstName,
                LastName = laboratoryPatientModel.LastName,
                GenderId = laboratoryPatientModel.Gender,
                UserName = laboratoryPatientModel.Username,
                PhoneNumber = phoneNumber,
                Role = "LaboratoryUser",
                JoinOnDate = globalService.ReturnDateToString(),
                LaboratoryPatient = new LaboratoryPatient()
                {
                    Egn = laboratoryPatientModel.Egn,
                }
            };

            return await userManager.CreateAsync(user, laboratoryPatientModel.Password);
        }

        public async Task<CreateLaboratoryPatientViewModel> SearchLaboratoryPatientByEgnAsync(string egn)
        {
            var existLaborantPatient = await repository.All<LaboratoryPatient>()
                .Where(d => d.Egn == egn)
                .Select(d => new CreateLaboratoryPatientViewModel
                {
                    Id = d.Id,
                    Egn = d.Egn,
                    FirstName = d.User.FirstName,
                    Gender = d.User.GenderId,
                    PhoneNumber = d.User.PhoneNumber,
                    LastName = d.User.LastName,
                    Role = d.User.Role
                })
                .FirstOrDefaultAsync();

            return existLaborantPatient;
        }

        public async Task<ShowAllLaboratoryPatientViewModel> GetAllCurrentLaboratoryPatientAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant)
        {
            var laboratoryPatientQuery = repository.All<LaboratoryPatient>()
                .OrderBy(x => x.User.FirstName)
                .ThenBy(x => x.User.LastName)
                .AsQueryable();

            if (string.IsNullOrEmpty(searchTermEgn) == false)
            {
                laboratoryPatientQuery = laboratoryPatientQuery
                    .Where(d => d.Egn == searchTermEgn);
            }

            if (string.IsNullOrEmpty(searchTermName) == false)
            {
                searchTermName = $"%{searchTermName}%".ToLower();

                laboratoryPatientQuery = laboratoryPatientQuery
                    .Where(d => EF.Functions.Like(d.User.FirstName.ToLower(), searchTermName) || EF.Functions.Like(d.User.LastName.ToLower(), searchTermName));
            }

            var laboratoryPatients = await laboratoryPatientQuery
                .Skip((currentPage - 1) * laboratoryPatientPerPage)
                .Take(laboratoryPatientPerPage)
                .Select(d => new DashboardLaboratoryPatientViewModel
                {
                    FirstName = d.User.FirstName,
                    Id = d.Id,
                    JoinOnDate = d.User.JoinOnDate,
                    LastName = d.User.LastName,
                    PhoneNumber = d.User.PhoneNumber,
                    Egn = d.Egn
                })
                .ToListAsync();

            return new ShowAllLaboratoryPatientViewModel
            {
                LaboratoryPatients = laboratoryPatients,
                TotalLaboratoryPatientCount = laboratoryPatientQuery.Count()
            };
        }

        public async Task UploadResultAsync(UploadTestResultViewModel model)
        {
            var patient = await repository.GetByIdAsync<LaboratoryPatient>(model.LaboratoryPatientId);

            var test = new Test
            {
                LaboratoryPatientId = patient.Id,
                LaboratoryPatient = patient,
                Hct = model.Hct,
                Hgb = model.Hgb,
                MCH = model.MCH,
                MCHC = model.MCHC,
                MCV = model.MCV,
                Plt = model.Plt,
                RBC = model.RBC,
                UrineGravity = model.UrineGravity,
                UrinepH = model.UrinepH,
                WBC = model.WBC,
                TestDate = DateTime.Now
            };

            patient.Tests.Add(test);
            await repository.AddAsync(test);
            await repository.SaveChangesAsync();
        }
    }
}
