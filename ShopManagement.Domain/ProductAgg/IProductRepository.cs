using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long , Product>
    {
        EditProduct GetDetails(long id);
        Product GetProductWithCategoryById(long id);
        List<ProductViewModel> GetProducts();
        string GetProductWithSlugById(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
