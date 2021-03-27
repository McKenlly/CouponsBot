using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using CouponsBot.Domain.Models;
using EntityDbContext = System.Data.Entity.DbContext;
using CouponsBot.Persistence.Configurations;

namespace CouponsBot.Persistence.DbContext
{
    public class MySqlDbContext : EntityDbContext
    {
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        
        public MySqlDbContext() : base("MySqlConnectionString") {}
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CompanyEntityTypeConfiguration).Assembly);
            modelBuilder.Configurations.AddFromAssembly(typeof(CouponEntityTypeConfiguration).Assembly);
            modelBuilder.Configurations.AddFromAssembly(typeof(RatingEntityTypeConfiguration).Assembly);
            modelBuilder.Configurations.AddFromAssembly(typeof(UserCouponEntityTypeConfiguration).Assembly);
            modelBuilder.Configurations.AddFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
        }
        
    }
}