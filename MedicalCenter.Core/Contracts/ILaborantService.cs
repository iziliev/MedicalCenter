using MedicalCenter.Core.Models.Laborant;
using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Contracts
{
    /// <summary>
    /// Laborant manipulation
    /// </summary>
    public interface ILaborantService
    {
        /// <summary>
        /// Search laboratory patient by Egn
        /// </summary>
        /// <param name="egn">record egn</param>
        /// <returns>CreateLaboratoryPatientViewModel</returns>
        Task<CreateLaboratoryPatientViewModel> SearchLaboratoryPatientByEgnAsync(string egn);

        /// <summary>
        /// Create laboratory patient
        /// </summary>
        /// <param name="laboratoryPatientModel">CreateLaboratoryPatientViewModel</param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> CreateLaboratoryPatientAsync(CreateLaboratoryPatientViewModel laboratoryPatientModel);

        /// <summary>
        /// show laboratory patient by egn
        /// </summary>
        /// <param name="egn">record egn</param>
        /// <returns>LaboratoryPatient</returns>
        Task<LaboratoryPatient> GetLaboratoryPatientByEgnAsync(string egn);

        /// <summary>
        /// Add laboratory patient to role
        /// </summary>
        /// <param name="laboratoryPatient">User</param>
        /// <param name="laboratoryPatientRole">role</param>
        Task AddLaboratoryPatientRoleAsync(User laboratoryPatient, string laboratoryPatientRole);

        /// <summary>
        /// All laboratory patient
        /// </summary>
        /// <param name="searchTermEgn">search term egn</param>
        /// <param name="searchTermName">search term name</param>
        /// <param name="currentPage">current page</param>
        /// <param name="laboratoryPatientPerPage">laboratory patient per page</param>
        /// <returns>laboratory patients</returns>
        Task<ShowAllLaboratoryPatientViewModel> GetAllCurrentLaboratoryPatientAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        /// <summary>
        /// Upload result from test
        /// </summary>
        /// <param name="model">UploadTestResultViewModel</param>
        Task UploadResultAsync(UploadTestResultViewModel model);
    }
}
