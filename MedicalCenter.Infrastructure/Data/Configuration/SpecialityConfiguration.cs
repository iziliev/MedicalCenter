using MedicalCenter.Infrastructure.Data.Models;
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
    internal class SpecialityConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasData(SeedSpecialtyBase());
        }

        private List<Specialty> SeedSpecialtyBase()
        {
            var specialtyInMc = SpecialtyConstants.AllSpecialties
            .Split(",")
            .ToList();

            var specialties = new List<Specialty>();

            for (int i = 0; i < specialtyInMc.Count; i++)
            {
                specialties.Add(new Specialty { Id = i + 1, Name = specialtyInMc[i] });
            }

            return specialties;
        }
    }
}
