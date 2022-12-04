using MedicalCenter.Core.Models.Api;
using MedicalCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Contracts
{
    /// <summary>
    /// Api statistic
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Statistic home
        /// </summary>
        /// <returns>DashboardStatisticViewModel</returns>
        Task<DashboardStatisticViewModel> GetStatisticHome();

        /// <summary>
        /// Statistic admin laboratory
        /// </summary>
        /// <returns>DashboardStatisticViewModel</returns>
        Task<DashboardStatisticViewModel> GetStatisticAdminLaboratory();

        /// <summary>
        /// Statistic admin medical center
        /// </summary>
        /// <returns>DashboardStatisticViewModel</returns>
        Task<DashboardStatisticViewModel> GetStatisticAdminMedical();

        /// <summary>
        /// Statistic laborant
        /// </summary>
        /// <returns>DashboardStatisticViewModel</returns>
        Task<DashboardStatisticViewModel> GetStatisticLaborant();
    }
}
