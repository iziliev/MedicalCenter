using MedicalCenter.Infrastructure.Data.Global;

namespace MedicalCenter.Core.Models.Laborant
{
    public class ShowAllLaboratoryPatientViewModel
    {
        public const int LaboratoryPatientPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalLaboratoryPatientCount { get; set; }

        public string? SearchTermEgn { get; set; }

        public string? SearchTermName { get; set; }

        public IEnumerable<DashboardLaboratoryPatientViewModel> LaboratoryPatients { get; set; } = new List<DashboardLaboratoryPatientViewModel>();
    }
}
