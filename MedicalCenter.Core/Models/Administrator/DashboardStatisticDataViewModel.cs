using MedicalCenter.Infrastructure.Data.Models;

namespace MedicalCenter.Core.Models.Administrator
{
    public class DashboardStatisticDataViewModel
    {
        public Dictionary<string, int> Shedules { get; set; } = new Dictionary<string, int>();

        public Dictionary<string, int> Specialties { get; set; } = new Dictionary<string, int>();

        public IEnumerable<KeyValuePair<string, int>> Top5Specialises { get; set; } = new List<KeyValuePair<string, int>>();

        public Dictionary<string, int> DoctorsExaminations { get; set; } = new Dictionary<string, int>();

        public IEnumerable<KeyValuePair<string, int>> Top5DoctorExamination { get; set; } = new List<KeyValuePair<string, int>>();

        public long SumAllRaings { get; set; }

        public long CountRaings { get; set; }

        public Dictionary<string, List<int>> DoctorsRating { get; set; } = new Dictionary<string, List<int>>();
    }
}
