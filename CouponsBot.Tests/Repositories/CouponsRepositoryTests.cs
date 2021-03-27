using System.Collections.Generic;
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
            await using var context = GetContextAsync();
            var repository = new CouponsRepository(context);
            await repository.AddAsync(new Coupon()
            {
                Name = "Воппер комбо",
                Description = "Вкусно, атвичаю",
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
        
        [Fact]
        public async Task CouponsRepository_AddRangeAsync()
        {
            await using var context = GetContextAsync();
            var repository = new CouponsRepository(context);
            await repository.AddRangeAsync(new List<Coupon>() 
            {
                new Coupon()
                {
                    Name = "Воппер комбо",
                    Description = "Вкусно, атвичаю",
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
                },
                new Coupon()
                {
                    Name = "Воппер комбо2",
                    Description = "Вкусно, не атвичаю",
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
                },
                new Coupon()
                {
                    Name = "Шефбургер",
                    Description = "Вкусно, не атвичаю",
                    Company = new Company()
                    {
                        Name = "KFC",
                        Description = "Кифас"
                    },
                    DiscountAmount = 300,
                    OldPrice = 30,
                    Price = 250,
                    IsArchived = true,
                    IsWorked = false
                },
            });
            var coupon = repository.ListAllByCompany(1);
            Assert.Equal(1, coupon.Count);
        }

        private DbContext GetContextAsync()
        {
            var contextOptions = new DbContextOptionsBuilder<MySqlDbContext>()
                .UseInMemoryDatabase(databaseName: "CouponsDb")
                .Options;
           return new MySqlDbContext(contextOptions);
        }
    }
}