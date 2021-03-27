using CouponsBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouponsBot.Persistence.Configurations
{
    public class UserCouponEntityTypeConfiguration : IEntityTypeConfiguration<UserCoupon>
    {
        public void Configure(EntityTypeBuilder<UserCoupon> builder)
        {
            builder.ToTable("UserCoupon");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserCoupons)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Coupon)
                .WithMany(x => x.UserCoupons)
                .HasForeignKey(x => x.CouponId);
        }
    }
}