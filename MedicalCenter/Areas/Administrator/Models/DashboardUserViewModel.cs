namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// User view model
    /// </summary>
    public class DashboardUserViewModel
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Join date
        /// </summary>
        public string? JoinOnDate { get; set; }
    }
}
