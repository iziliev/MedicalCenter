using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalCenter.Core.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterViewModel registerModel);

        Task<bool> IsUsernameExist(string username);

        Task<bool> IsEmailExist(string username);

        Task<SignInResult> Login(LoginViewModel loginModel);

        Task Logout();

        Task<User> GetUserByUsername(string username);

        Task<IEnumerable<AllDoctorUserViewModel>> ShowDoctorOnUser();

        Task<IEnumerable<string>> GetWorkHoursByDoctorId (string doctorId);

        Task<Doctor> GetDoctorById(string doctorId);

        Task CreateExamination(User user,Doctor doctor, BookExaminationViewModel bookModel);

        Task<bool> IsUserFreeOnDateAnHour(string userId, BookExaminationViewModel bookModel);

        Task<bool> IsDoctorFreeOnDateAnHour(BookExaminationViewModel bookModel);

        Task<string> ReturnDoctorName(string doctorId);

        Task<IEnumerable<UserExaminationViewModel>> GetAllCurrentExamination(string userId);

        Task CancelUserExamination(string examinationId);

        Task<BookExaminationViewModel> FillBookViewModel(string doctorId);

        Task<IEnumerable<ExaminationForReviewViewModel>> GetAllExaminationForReview(string userId);

        Task<Examination> GetExaminationAsync(string userId, BookExaminationViewModel bookModel);
    }
}