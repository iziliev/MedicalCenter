using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Contracts
{
    public interface IApiService
    {
        Task<DoctorModel> GetDoctorByEgnAsync(string egn);

        Task<TestModel> GetTestByIdAsync(string testId);

        Task<StatisticsModel> GetInfo();

        Task<IEnumerable<DoctorModel>> GetAllDoctors();
    }
}
