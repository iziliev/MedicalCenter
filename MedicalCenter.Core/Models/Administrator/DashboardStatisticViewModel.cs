using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.Administrator
{
    public class DashboardStatisticViewModel
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
    }
}
