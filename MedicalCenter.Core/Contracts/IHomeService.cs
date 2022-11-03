using MedicalCenter.Core.Models.Administrator;

namespace MedicalCenter.Core.Contracts
{
    public interface IHomeService
    {
        DashboardStatisticViewModel Statistics();
    }
}
