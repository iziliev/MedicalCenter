using MedicalCenter.Core.Models.Administrator;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Contracts
{
    public interface IGlobalService
    {
        Task<Doctor> GetDoctorByIdAsync(string id);

        Task<User> GetUserById(string id);

        Task AddUserRoleAsync(User user, string userRole);

        Task AddClaimAsync(User user);

        Task<IEnumerable<Specialty>> GetSpecialtiesAsync();

        Task<IEnumerable<Shedule>> GetShedulesAsync();

        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<MainDoctorViewModel> FillGendersSpecialitiesSheduleInEditViewAsyanc(MainDoctorViewModel doctorEditModel);

        Task<CreateDoctorViewModel> FillGendersSpecialitiesSheduleInCreateViewAsyanc(CreateDoctorViewModel doctorCreateModel);
    }
}