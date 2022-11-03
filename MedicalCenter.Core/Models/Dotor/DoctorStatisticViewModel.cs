namespace MedicalCenter.Core.Models.Dotor
{
    public class DoctorStatisticViewModel
    {
        public int Examinations { get; set; }

        public int AllExaminations { get; set; }

        public string DoctorFullName { get; set; } = null!;

        public double Rating { get; set; }

        public int RatingUser { get; set; }
    }
}
