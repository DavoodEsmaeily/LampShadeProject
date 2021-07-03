using _0_Framework.Domain;
using System;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {

        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public long ProductId { get; private set; }
        public string Reason { get; private set; }

        public CustomerDiscount(string reason, int discountRate, DateTime startDate, DateTime endDate, long productId)
        {
            Reason = reason;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            ProductId = productId;
        }

        public void Edit(string reason, int discountRate, DateTime startDate, DateTime endDate, long productId)
        {
            Reason = reason;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            ProductId = productId;
        }
    }
}
