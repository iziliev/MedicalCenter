using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Areas.Administrator.Models
{
    /// <summary>
    /// Statistic data
    /// </summary>
    public class DashboardStatisticDataViewModel
    {
        /// <summary>
        /// Shedules
        /// </summary>
        public Dictionary<string, int> Shedules { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Specialities
        /// </summary>
        public Dictionary<string, int> Specialties { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Top 5 specialities
        /// </summary>
        public IEnumerable<KeyValuePair<string, int>> Top5Specialises { get; set; } = new List<KeyValuePair<string, int>>();

        /// <summary>
        /// Doctor examination
        /// </summary>
        public Dictionary<string, int> DoctorsExaminations { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Top 5 Doctor by examination
        /// </summary>
        public IEnumerable<KeyValuePair<string, int>> Top5DoctorExamination { get; set; } = new List<KeyValuePair<string, int>>();

        /// <summary>
        /// All doctor rating
        /// </summary>
        public long SumAllRaings { get; set; }

        /// <summary>
        /// Count rating
        /// </summary>
        public long CountRaings { get; set; }

        /// <summary>
        /// Doctor rating
        /// </summary>
        public Dictionary<string, List<int>> DoctorsRating { get; set; } = new Dictionary<string, List<int>>();
    }
}
