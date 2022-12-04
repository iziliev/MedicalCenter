namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Examination view model
    /// </summary>
    public class DashboardExaminationViewModel
    {
        /// <summary>
        /// Doctor id
        /// </summary>
        public string? DoctorId { get; set; }

        /// <summary>
        /// Doctor full name
        /// </summary>
        public string DoctorFullName { get; set; } = null!;

        /// <summary>
        /// Speciality name
        /// </summary>
        public string? SpecialityName { get; set; }

        /// <summary>
        /// speciality id
        /// </summary>
        public int SpecialityId { get; set; }

        /// <summary>
        /// Patient id
        /// </summary>
        public string? PatientId { get; set; }

        /// <summary>
        /// Patient full name
        /// </summary>
        public string PatientFullName { get; set; } = null!;

        /// <summary>
        /// examination date
        /// </summary>
        public string ExaminationDate { get; set; } = null!;

        /// <summary>
        /// Examination hour
        /// </summary>
        public string ExaminationHour { get; set; } = null!;
    }
}
