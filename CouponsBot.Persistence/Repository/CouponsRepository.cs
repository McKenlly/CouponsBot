using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using CouponsBot.Interfaces.Repositories;
using Hazzik.Maybe;
using Microsoft.EntityFrameworkCore;

namespace CouponsBot.Persistence.Repository
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<Coupon> _coupons;

        public CouponsRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _context = dbContext;
            _coupons = _context.Set<Coupon>();
        }

        public async Task AddAsync(Coupon coupon)
        {
            await _coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coupon coupon)
        {
            var result = await FindCouponByNameAsync(coupon.Name);
            result.Select(x => _coupons.Update(x));
            await _context.SaveChangesAsync();
        }

        public IReadOnlyCollection<Coupon> ListAllByCompany(int companyId)
        {
            return _coupons.Where<Coupon>(x => x.CompanyId == companyId).ToArray();
        }

        public async Task AddRangeAsync(IReadOnlyCollection<Coupon> coupons)
        {
            await _coupons.AddRangeAsync(coupons);
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

        public async Task<Maybe<Coupon>> FindCouponByNameAsync(string name)
        {
            var coupon = await _coupons.Where(x => x.Name == name).FirstOrDefaultAsync();
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