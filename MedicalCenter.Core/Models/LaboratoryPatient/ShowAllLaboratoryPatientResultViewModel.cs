using MedicalCenter.Core.Models.Dotor;
using MedicalCenter.Infrastructure.Data.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.LaboratoryPatient
{
    public class ShowAllLaboratoryPatientResultViewModel
    {
        public const int ResultsPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;

        public string? SearchTermDate { get; set; }

        public int TotalResultCount { get; set; }

        public IEnumerable<DashboardLaboratoryPatientResultViewModel> AllResults { get; set; } = new List<DashboardLaboratoryPatientResultViewModel>();
    }
}
