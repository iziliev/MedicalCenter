﻿using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class WorkHourConfiguration : IEntityTypeConfiguration<WorkHour>
    {
        public void Configure(EntityTypeBuilder<WorkHour> builder)
        {
            builder.HasData(SeedWorkHourBase());
        }

        private List<WorkHour> SeedWorkHourBase()
        {
            var hoursData = WorkHourConstants.AllWorkingHours
            .Split(",")
            .ToList();

            var hours = new List<WorkHour>();

            for (int i = 0; i < hoursData.Count; i++)
            {
                if (i < 8)
                {
                    hours.Add(new WorkHour { Id = i + 1, Hour = hoursData[i], SheduleId = 1 });
                }
                else
                {
                    hours.Add(new WorkHour { Id = i + 1, Hour = hoursData[i], SheduleId = 2 });
                }
            }

            return hours;
        }
    }
}
