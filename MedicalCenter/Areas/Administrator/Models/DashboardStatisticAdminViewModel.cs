namespace MedicalCenter.Areas.Administrator.Models
{
    public class DashboardStatisticAdminViewModel
    {
        public string BestRatingDoctorFullName { get; set; } = null!;

        public double BestDoctorRating { get; set; }

        public string BestExaminationDoctorFullName { get; set; } = null!;

        public int BestExaminationCount { get; set; }

        public int AllDoctorCount { get; set; }

        public int AllDoctorOutCount { get; set; }

        public int AllUserCount { get; set; }

        public int AllReviews { get; set; }

        public int AllExamination { get; set; }

        public int AllPastExamination { get; set; }

        public int AllFutureExamination { get; set; }
    }
}
