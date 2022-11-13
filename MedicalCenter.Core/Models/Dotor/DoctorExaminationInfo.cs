namespace MedicalCenter.Core.Models.Dotor
{
    public class DoctorExaminationInfo
    {
        public IEnumerable<DoctorExaminationViewModel> DoctorExaminations { get; set; } = new List<DoctorExaminationViewModel>();

        public DoctorStatisticViewModel DoctorStatistics { get; set; } = null!;
    }
}
