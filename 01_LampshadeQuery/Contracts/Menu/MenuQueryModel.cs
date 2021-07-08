using _01_LampshadeQuery.Contracts.ProductCategory;
using System.Collections.Generic;

namespace _01_LampshadeQuery.Contracts.Menu
{
    public class MenuQueryModel
    {
       public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
