using MedicalCenter.Core.Models.LaboratoryPatient;
using MedicalCenter.Infrastructure.Data.Global;
using Microsoft.AspNetCore.Identity;

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
