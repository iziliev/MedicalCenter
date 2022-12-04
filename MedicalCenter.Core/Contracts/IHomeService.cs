using MedicalCenter.Core.Models.Api;

namespace MedicalCenter.Core.Contracts
{
    public interface IHomeService
    {
        /// <summary>
        /// Statistic in homepage
        /// </summary>
        /// <returns>DashboardStatisticViewModel</returns>
        DashboardStatisticViewModel Statistics();
    }
}
