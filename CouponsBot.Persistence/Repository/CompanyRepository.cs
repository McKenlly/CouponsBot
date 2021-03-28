using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponsBot.Domain.Models;
using CouponsBot.Interfaces.Repositories;
using Hazzik.Maybe;
using Microsoft.EntityFrameworkCore;

namespace CouponsBot.Persistence.Repository
{
    public class CompanyRepository : ICompanyAccessor
    {
        private readonly Microsoft.EntityFrameworkCore.DbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<Company> _companies;

        public CompanyRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _context = dbContext;
            _companies = _context.Set<Company>();
        }

        public async Task<Maybe<Company>> FindCompanyByIdAsync(int id)
        {
            var company = await _companies.FindAsync();
            return company.ToMaybe();
        }

        public async Task<Maybe<Company>> FindCompanyByNameAsync(string name)
        {
            var company = await _companies.Where(x => x.Name == name).FirstOrDefaultAsync();
            return company.ToMaybe();
        }

        public async Task<Maybe<Company>> FindCompanyByCouponAsync(Coupon coupon)
        {
            var res = await _context.Set<Coupon>().FindAsync(coupon);
            return res.Company;
        }
    }
}