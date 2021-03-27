using CouponsBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouponsBot.Persistence.Configurations
{
    public class CouponEntityTypeConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupons");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.SecretCode);
            builder.Property(x => x.Price);
            builder.Property(x => x.OldPrice);
            builder.Property(x => x.DiscountAmount);
            builder.Property(x => x.PeriodWorks.DateFrom);
            builder.Property(x => x.PeriodWorks.DateTo);
            builder.Property(x => x.IsArchived);
            builder.Property(x => x.IsWorked);

            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.Coupons)
                .HasForeignKey(x => x.CompanyId);

            builder
                .HasMany(x => x.Ratings)
                .WithOne(x => x.Coupon)
                .HasForeignKey(x => x.CouponId);

            builder
                .HasMany(x => x.UserCoupons)
                .WithOne(x => x.Coupon)
                .HasForeignKey(x => x.CouponId);
        }
    }
}