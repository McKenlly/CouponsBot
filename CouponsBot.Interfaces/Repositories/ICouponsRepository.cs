using System.Collections.Generic;
using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using Hazzik.Maybe;

namespace CouponsBot.Interfaces.Repositories
{
    public interface ICouponsRepository
    {
        public Task AddAsync(Coupon coupon);
        public Task<IReadOnlyCollection<Coupon>> ListAllAsync();
        public Task AddRangeAsync(IReadOnlyCollection<Coupon> coupons);
        public Task RemoveCouponAsync(Coupon coupon);
        public Task RemoveCouponByIdAsync(int id);
        public Task<Maybe<Coupon>> FindCouponByIdAsync(int id);
        public Task<bool> IsExistByCouponByIdAsync(int id);
        public Task<bool> IsExistByCouponAsync(Coupon coupon);
    }
}