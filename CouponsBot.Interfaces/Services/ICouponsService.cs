using System.Threading.Tasks;
using CouponsBot.Domain.Models;

namespace CouponsBot.Interfaces.Services
{
    public interface ICouponsService
    {
        Task AddCoupon(Coupon coupon);
        Task UpdateCoupon(Coupon coupon);
        
    }
}