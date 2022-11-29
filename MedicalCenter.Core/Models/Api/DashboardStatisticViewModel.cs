namespace MedicalCenter.Core.Models.Api
{
    public class DashboardStatisticViewModel
    {
        public string BestRatingDoctorFullName { get; set; } = null!;

        public string? BestDoctorRating { get; set; }

        public string BestExaminationDoctorFullName { get; set; } = null!;

        public int BestExaminationCount { get; set; }

        public int AllDoctorCount { get; set; }

        public int AllDoctorOutCount { get; set; }

        public int AllUserCount { get; set; }

        public int AllReviews { get; set; }

        public int AllExamination { get; set; }

        public int AllPastExamination { get; set; }

        public int AllFutureExamination { get; set; }

        public int AllTest { get; set; }
    }
}
