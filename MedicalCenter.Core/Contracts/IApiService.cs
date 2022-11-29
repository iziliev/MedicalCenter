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
        Task<DashboardStatisticViewModel> GetStatisticHome();

        Task<DashboardStatisticViewModel> GetStatisticAdminLaboratory();

        Task<DashboardStatisticViewModel> GetStatisticAdminMedical();

        Task<DashboardStatisticViewModel> GetStatisticLaborant();
    }
}
