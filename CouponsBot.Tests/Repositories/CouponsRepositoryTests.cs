using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using CouponsBot.Interfaces.Repositories;
using CouponsBot.Persistence.DbContext;
using CouponsBot.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CouponsBot.Tests.Repositories
{
    public class CouponsRepositoryTests
    {
        [Fact]
        public async Task CouponsRepository_AddOrUpdateAsync()
        {
            var contextOptions = new DbContextOptionsBuilder<MySqlDbContext>()
                .UseInMemoryDatabase(databaseName: "CouponsDb")
                .Options;
            using var context = new MySqlDbContext(contextOptions);
            var repository = new CouponsRepository(context);
            await repository.AddAsync(new Coupon()
            {
                Name = "Воппер комбо",
                Description = "Вкусная хуйня",
                Company = new Company()
                {
                    Name = "McDonalds",
                    Description = "Макдак"
                },
                DiscountAmount = 3,
                OldPrice = 3,
                Price = 43,
                IsArchived = true,
                IsWorked = false
            });
            var coupon = await repository.FindCouponByIdAsync(1);
            Assert.NotNull(coupon.Value);
        }
    }
}