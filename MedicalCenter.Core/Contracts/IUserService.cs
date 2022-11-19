﻿using MedicalCenter.Core.Models.User;
using MedicalCenter.Infrastructure.Data.Global;
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

        Task<ShowAllDoctorUserViewModel> ShowDoctorOnUserAsync(
            string? speciality = null, 
            string? searchTerm = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int doctorsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllUserExaminationViewModel> GetAllCurrentExaminationAsync(
            string userId,
            string? speciality = null, 
            string? searchTermDate = null, 
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int examinationsPerPage = DataConstants.PagingConstants.ShowPerPageConstant);

        Task<ShowAllExaminationForReviewViewModel> GetAllExaminationForReviewAsync(
            string userId, 
            string? speciality = null,
            string? searchTermDate = null,
            string? searchTermName = null, 
            int currentPage = DataConstants.PagingConstants.CurrentPageConstant, 
            int reviewPerPage = DataConstants.PagingConstants.ShowPerPageConstant);
    }
}