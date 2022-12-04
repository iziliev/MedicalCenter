namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Statistic admin view model
    /// </summary>
    public class DashboardStatisticAdminViewModel
    {
        /// <summary>
        /// All count admins
        /// </summary>
        public int AllAdministratorCount { get; set; }

        /// <summary>
        /// All left admins
        /// </summary>
        public int AllAdministratorOutCount { get; set; }
    }
}
