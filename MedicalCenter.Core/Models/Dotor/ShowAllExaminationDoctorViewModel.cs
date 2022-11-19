using MedicalCenter.Infrastructure.Data.Global;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Core.Models.Dotor
{
    public class ShowAllExaminationDoctorViewModel
    {
        public const int ExaminationPerPage = DataConstants.PagingConstants.ShowPerPageConstant;

        public int CurrentPage { get; set; } = DataConstants.PagingConstants.CurrentPageConstant;
        
        public string? SearchTerm { get; set; }

        public int TotalExaminationCount { get; set; }

        public IEnumerable<DashboardDoctorExaminationViewModel> AllExamination { get; set; } = new List<DashboardDoctorExaminationViewModel>();

    }
}
