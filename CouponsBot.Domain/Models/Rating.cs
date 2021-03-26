namespace CouponsBot.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public int Mark { get; set; }
    }
}