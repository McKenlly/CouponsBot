﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using CouponsBot.Interfaces.Repositories;
using Hazzik.Maybe;

namespace CouponsBot.Persistence.Repository
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly System.Data.Entity.DbContext _context;
        private readonly DbSet<Coupon> _coupons;

        public CouponsRepository(System.Data.Entity.DbContext dbContext)
        {
            _context = dbContext;
            _coupons = _context.Set<Coupon>();
        }

        public async Task AddOrUpdateAsync(Coupon coupon)
        {
            _coupons.AddOrUpdate(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IReadOnlyCollection<Coupon> coupons)
        {
            _coupons.AddRange(coupons);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCouponAsync(Coupon coupon)
        {
            _coupons.Remove(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCouponByIdAsync(int id)
        {
            var coupon = await _coupons.Where(x => x.Id == id).FirstOrDefaultAsync();
            await RemoveCouponAsync(coupon);
        }

        public async Task<Maybe<Coupon>> FindCouponByIdAsync(int id)
        {
            var coupon = await _coupons.FindAsync(id);
            return coupon.ToMaybe();
        }

        public async Task<bool> IsExistByCouponByIdAsync(int id)
        {
            var coupon = await _coupons.FindAsync(id);
            return coupon != null;
        }

        public async Task<bool> IsExistByCouponAsync(Coupon coupon)
        {
            var res = await _coupons.FindAsync(coupon);
            return res != null;
        }
    }
}