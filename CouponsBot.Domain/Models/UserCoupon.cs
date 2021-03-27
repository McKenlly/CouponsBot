namespace CouponsBot.Domain.Models
{
    /// <summary>
    /// Many-to-many relationship
    /// </summary>
    public class UserCoupon
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}