using System.Collections.Generic;

namespace CouponsBot.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public IReadOnlyCollection<Coupon> Coupons { get; set; }
    }
}