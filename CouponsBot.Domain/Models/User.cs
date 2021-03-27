using System.Collections.Generic;

namespace CouponsBot.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Cookie { get; set; }
        public IReadOnlyCollection<UserCoupon> UserCoupons { get; set; }
        public IReadOnlyCollection<Rating> UserRatings { get; set; }
    }
}