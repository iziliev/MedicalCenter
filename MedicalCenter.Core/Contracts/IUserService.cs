using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterViewModel registerModel);

        Task<bool> IsUsernameExistAsync(string username);

        Task<bool> IsUserEmailExistAsync(string username);

        Task<SignInResult> Login(LoginViewModel loginModel);

        Task Logout();

        Task<User> GetUserByUsernameAsync(string username);

        Task<IEnumerable<string>> GetDoctorWorkHoursByDoctorIdAsync (string doctorId);

        Task<Doctor> GetDoctorByIdAsync(string doctorId);

        Task CreateExaminationAsync(User user,Doctor doctor, BookExaminationViewModel bookModel);

        Task<bool> IsUserFreeOnDateAnHourAsync(string userId, BookExaminationViewModel bookModel);

        Task<bool> IsDoctorFreeOnDateAnHourAsync(BookExaminationViewModel bookModel);

        Task<string> ReturnDoctorNameByDoctorIdAsync(string doctorId);

        Task CancelUserExaminationAsync(string examinationId);

        Task<BookExaminationViewModel> FillBookViewModelAsync(string doctorId);

        Task<Examination> GetExaminationByIdAsync(string id);

        Task<Examination> GetExaminationAsync(string userId, BookExaminationViewModel bookModel);

        Task<ShowAllDoctorUserViewModel> ShowDoctorOnUserAsync(int currentPage = 1, int doctorsPerPage = 4);

        Task<ShowAllUserExaminationViewModel> GetAllCurrentExaminationAsync(string userId, int currentPage = 1, int examinationsPerPage = 6);

        Task<ShowAllExaminationForReviewViewModel> GetAllExaminationForReviewAsync(string userId, int currentPage = 1, int examinationsPerPage = 6);

        Task<List<AuthenticationScheme>> AutenticationSheme();

        AuthenticationProperties AuthenticationProperties(string provider, string redirectUrl);

        Task<ExternalLoginInfo> GetExternalLoginInfo();

        Task<SignInResult> GetSignInExternalResult(ExternalLoginInfo info);
    }
}