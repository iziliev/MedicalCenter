namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Laborant view model
    /// </summary>
    public class DashboardLaborantViewModel
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
