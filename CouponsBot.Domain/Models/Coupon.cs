using CouponsBot.Domain.Enums;

namespace CouponsBot.Domain.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public SourceType SourceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SecretCode { get; set; }
        public PeriodWorks PeriodWorks { get; set; }
        public bool IsWorked { get; set; }
    }
}