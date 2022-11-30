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
    public interface ILaborantService
    {
        Task<CreateLaboratoryPatientViewModel> SearchLaboratoryPatientByEgnAsync(string egn);

        Task<IdentityResult> CreateLaboratoryPatientAsync(CreateLaboratoryPatientViewModel laboratoryPatientModel);

        Task<LaboratoryPatient> GetLaboratoryPatientByEgnAsync(string egn);

        Task AddLaboratoryPatientRoleAsync(User laboratoryPatient, string laboratoryPatientRole);

        Task<ShowAllLaboratoryPatientViewModel> GetAllCurrentLaboratoryPatientAsync(
            string? searchTermEgn = null,
            string? searchTermName = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task UploadResultAsync(UploadTestResultViewModel model);
    }
}
