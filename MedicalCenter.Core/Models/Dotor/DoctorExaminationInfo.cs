namespace MedicalCenter.Core.Models.Dotor
{
    public class DoctorExaminationInfo
    {
        public IEnumerable<DashboardDoctorExaminationViewModel> DoctorExaminations { get; set; } = new List<DashboardDoctorExaminationViewModel>();

        public DoctorStatisticViewModel DoctorStatistics { get; set; } = null!;
    }
}
