using System;
using System.Collections.Generic;
using System.Linq;
using CouponsBot.Domain.Enums;

namespace CouponsBot.Domain.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SecretCode { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public double DiscountAmount { get; set; }
        public PeriodWorks PeriodWorks { get; set; }
        public bool IsWorked { get; set; }
        public bool IsArchived { get; set; }

        #region aggretion Methods
        public int TotalReviews => Ratings.Count;
        public double AverageMark => Ratings.Average(x => x.Mark);
        #endregion
        
        public IReadOnlyCollection<Rating> Ratings { get; set; }
        public IReadOnlyCollection<UserCoupon> UserCoupons { get; set; }
    }
    
    public class PeriodWorks
    {
        public DateTime DateFrom { get; set;  }
        public DateTime DateTo { get; set;  }
    }
}