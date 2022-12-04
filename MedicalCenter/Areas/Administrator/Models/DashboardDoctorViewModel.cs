namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Doctor view model
    /// </summary>
    public class DashboardDoctorViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Speciality name
        /// </summary>
        public string? SpecialityName { get; set; }

        /// <summary>
        /// Speciality id
        /// </summary>
        public int SpecialityId { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Egn
        /// </summary>
        public string Egn { get; set; } = null!;

        /// <summary>
        /// Join date
        /// </summary>
        public string? JoinOnDate { get; set; }

        /// <summary>
        /// Left date
        /// </summary>
        public string? OutOnDate { get; set; }
    }
}
