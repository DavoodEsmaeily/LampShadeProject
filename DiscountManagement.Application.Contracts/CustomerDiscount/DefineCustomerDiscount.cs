using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public string Reason { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public long ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }
}
