using CouponsBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouponsBot.Persistence.Configurations
{
    public class RationEntityTypeConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserRatings)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Coupon)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.CouponId);

            builder.Property(x => x.Mark);
        }
    }
}