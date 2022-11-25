using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Core.Models.LaboratoryPatient;
using MedicalCenter.Infrastructure.Data.Global;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Contracts
{
    public interface ILaboratoryPatient
    {
        Task<SignInResult> Login(LoginPatientViewModel loginModel);

        Task<bool> IsEgnExistAsync(string egn);

        Task<bool> IsUsernameExistAsync(string username);

        Task<ShowAllLaboratoryPatientResultViewModel> GetAllResult(
            string userId,
            string? searchTermDate = null,
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant,
            int laboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ResultViewModel> GetResultByIdAsync(string id);
    }
}
