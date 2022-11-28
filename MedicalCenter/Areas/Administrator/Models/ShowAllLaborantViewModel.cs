using MedicalCenter.Infrastructure.Data.Global;
using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    public class ShowAllLaborantViewModel
    {
        public const int LaborantPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public int TotalLaborantsCount { get; set; }

        public string? SearchTermEgn { get; set; }

        public string? SearchTermName { get; set; }

        public IEnumerable<DashboardLaborantViewModel> Laborants { get; set; } = new List<DashboardLaborantViewModel>();
    }
}
