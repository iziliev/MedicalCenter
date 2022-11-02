using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(SeedGenderBase());
        }

        private List<Gender> SeedGenderBase()
        {
            var gender = "Мъж,Жена,Не посочвам"
            .Split(",")
            .ToList();

            var genders = new List<Gender>();

            for (int i = 0; i < gender.Count; i++)
            {
                genders.Add(new Gender { Id = i + 1, Name = gender[i] });
            }

            return genders;
        }
    }
}
