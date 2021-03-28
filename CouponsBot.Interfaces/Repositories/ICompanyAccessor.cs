using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using Hazzik.Maybe;

namespace CouponsBot.Interfaces.Repositories
{
    public interface ICompanyAccessor
    {
        public Task<Maybe<Company>> FindCompanyByIdAsync(int id);
        public Task<Maybe<Company>> FindCompanyByNameAsync(string name);
        public Task<Maybe<Company>> FindCompanyByCouponAsync(Coupon coupon);
    }
}