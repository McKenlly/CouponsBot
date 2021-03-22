using System.Collections.Generic;
using CouponsBot.Domain.Models;
using Hazzik.Maybe;

namespace CouponsBot.Interfaces.Repositories
{
    public interface ICouponsRepository
    {
        public void AddOrUpdate(Coupon coupon);
        public void AddOrUpdate(IReadOnlyCollection<Coupon> coupons);
        public void RemoveCoupon(Coupon coupon);
        public void RemoveCouponById(int id);
        public Maybe<Coupon> FindCouponById(int id);
        public bool IsExistByCouponById(int id);
        public bool IsExistByCoupon(Coupon coupon);
    }
}