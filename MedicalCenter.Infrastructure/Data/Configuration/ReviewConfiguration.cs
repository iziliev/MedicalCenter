using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenter.Infrastructure.Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(u => u.User)
                .WithMany(u => u.UserReviews)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Doctor)
                .WithMany(u => u.DoctorReviews)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
