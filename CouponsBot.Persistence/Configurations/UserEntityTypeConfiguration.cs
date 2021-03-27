using CouponsBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouponsBot.Persistence.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Mail);
            builder.Property(x => x.Cookie).IsRequired();

            builder
                .HasMany(x => x.UserCoupons)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}