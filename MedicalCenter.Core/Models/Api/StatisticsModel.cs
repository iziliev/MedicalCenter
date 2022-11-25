using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Core.Models.Api
{
    public class StatisticsModel
    {
        public int AllDoctors { get; set; }

        public int AllUsers { get; set; }

        public int AllExamination { get; set; }

        public int AllLaborants { get; set; }

        public int AllLaboratoryPatients { get; set; }

        public int AllTests { get; set; }
    }
}
