using MedicalCenter.Core.Models.Api;

namespace MedicalCenter.Core.Contracts
{
    public interface IHomeService
    {
        DashboardStatisticViewModel Statistics();
    }
}
