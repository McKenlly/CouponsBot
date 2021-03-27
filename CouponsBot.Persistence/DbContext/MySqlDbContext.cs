using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using CouponsBot.Domain.Models;
using CouponsBot.Persistence.Configurations;

namespace CouponsBot.Persistence.DbContext
{
    public class MySqlDbContext : System.Data.Entity.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Coupon> Coupons { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Rating> Ratings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Company> Companies { get; set; }
        
        public MySqlDbContext() : base("CoouponsDb") {}
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CompanyEntityTypeConfiguration).Assembly);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
    }
}