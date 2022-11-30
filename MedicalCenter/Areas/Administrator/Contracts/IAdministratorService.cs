﻿using MedicalCenter.Areas.Administrator.Models;
using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Areas.Contracts
{
    public interface IAdministratorService
    {
        Task<CreateAdminViewModel> SearchAdminByEgnAsync(string egn);

        Task<CreateDoctorViewModel> SearchDoctorByEgnAsync(string egn);

        Task<CreateLaborantViewModel> SearchLaborantByEgnAsync(string egn);

        Task<IdentityResult> CreateAdminAsync(CreateAdminViewModel doctorModel);

        Task<IdentityResult> CreateDoctorAsync(CreateDoctorViewModel doctorModel);

        Task<IdentityResult> CreateLaborantAsync(CreateLaborantViewModel laborantModel);

        Task ReturnAsync<T>(string id);

        Task<T> GetByEgnAsync<T>(string egn);

        Task<Infrastructure.Data.Models.Administrator> GetAdminByUserIdAsync(string id);

        Task<Infrastructure.Data.Models.Administrator> GetAdminByIdAsync(string id);

        Task<Doctor> GetDoctorByIdAsync(string id);

        Task<Laborant> GetLaborantByIdAsync(string id);

        Task AddAdminRoleAsync(User administrator, string adminRole);

        Task AddDoctorRoleAsync(User doctor, string doctorRole);

        Task AddLaborantRoleAsync(User laborant, string laborantRole);

        Task<MainDoctorViewModel> GetDoctorByIdToEditAsync(string id);

        Task<MainAdminViewModel> GetAdminByIdToEditAsync(string id);

        Task EditAdminAsync(MainAdminViewModel doctorModel, Infrastructure.Data.Models.Administrator admin);

        Task EditDoctorAsync(MainDoctorViewModel doctorModel, Doctor doctor);

        Task EditLaborantAsync(MainLaborantViewModel laborantModel, Laborant laborant);

        Task<MainLaborantViewModel> GetLaborantByIdToEditAsync(string id);

        Task DeleteAsync<T>(string id);

        Task<DashboardStatisticAdminViewModel> GetStatisticsAdminAsync();

        Task<DashboardStatisticDataViewModel> GetStatisticsDataAsync();

        Task<DashboardStatisticViewModel> GetStatisticsAsync();

        Task<DashboardStatisticLabViewModel> GetStatisticsLabAsync();

        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        Task<IEnumerable<Shedule>> GetShedulesAsync();

        Task<IEnumerable<Gender>> GetGendersAsync();

        Task Logout();

        Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel);

        Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel);

        Task<ShowAllExaminationViewModel> GetAllPastExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllExaminationViewModel> GetAllFutureExamination(
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllAdminViewModel> GetAllCurrentAdminAsync(
            string id,
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllDoctorViewModel> GetAllCurrentDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllLaborantViewModel> GetAllCurrentLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllUserViewModel> GetAllRegisteredUsersAsync(
            string? searchTermEmail = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllDoctorViewModel> GetAllLeftDoctorsAsync(
            string? speciality = null, 
            string? searchTermEgn = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllLaborantViewModel> GetAllLeftLaborantsAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laborantssPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllAdminViewModel> GetAllLeftAdminAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int adminsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}
