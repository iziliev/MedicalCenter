using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
    {
        public void Configure(EntityTypeBuilder<Examination> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.UserExaminations)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Doctor)
                .WithMany(e => e.DoctorExaminations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
