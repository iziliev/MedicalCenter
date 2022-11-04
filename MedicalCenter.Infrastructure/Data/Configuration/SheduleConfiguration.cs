using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static MedicalCenter.Infrastructure.Data.Global.DataConstants;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class SheduleConfiguration : IEntityTypeConfiguration<Shedule>
    {
        public void Configure(EntityTypeBuilder<Shedule> builder)
        {
            builder.HasData(SeedSheduleBase());
        }

        private List<Shedule> SeedSheduleBase()
        {
            var hoursData = WorkHourConstants.AllWorkingHours
            .Split(",")
            .ToList();

            var shedules = new List<Shedule>()
            {
                new Shedule { Id = 1, Name="Първа смяна" },
                new Shedule { Id = 2, Name="Втора смена" }
            };

            return shedules;
        }
    }
}
