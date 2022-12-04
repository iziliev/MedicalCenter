namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Statistic laborant
    /// </summary>
    public class DashboardStatisticLabViewModel
    {
        /// <summary>
        /// All count laborants
        /// </summary>
        public int AllLaborantCount { get; set; }

        /// <summary>
        /// All count left laborants
        /// </summary>
        public int AllLaborantOutCount { get; set; }

        /// <summary>
        /// All test count
        /// </summary>
        public int AllTestCount { get; set; }
    }
}
