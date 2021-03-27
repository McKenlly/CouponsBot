using CouponsBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouponsBot.Persistence.Configurations
{
    public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(32).IsUnicode().IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.IconUrl).IsRequired();

            builder
                .HasMany(x => x.Coupons)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}