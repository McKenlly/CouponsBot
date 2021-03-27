using CouponsBot.Domain.Models;
using CouponsBot.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CouponsBot.Persistence.DbContext
{
    public class MySqlDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Coupon> Coupons { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Rating> Ratings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Company> Companies { get; set; }

        public MySqlDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CouponEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserCouponEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}