using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using CouponsBot.Interfaces.Repositories;
using CouponsBot.Interfaces.Services;

namespace CouponsBot.Persistence.Services
{
    public class CouponsService : ICouponsService
    {
        private readonly ICouponsRepository _couponsRepository;

        public CouponsService(ICouponsRepository couponsRepository) 
            => _couponsRepository = couponsRepository;

        public async Task AddCoupon(Coupon coupon)
        {
            coupon.Company = null;
            coupon.Ratings = null;
            await _couponsRepository.AddAsync(coupon);
        }

        public async Task UpdateCoupon(Coupon coupon)
        {
            coupon.Company = null;
            coupon.Ratings = null;
            await _couponsRepository.UpdateAsync(coupon);
        }
    }
}