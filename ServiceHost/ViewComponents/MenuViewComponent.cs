using _01_LampshadeQuery.Contracts.Menu;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var menues = new MenuQueryModel
            {
                ProductCategories = _productCategoryQuery.GetProductCategories()
            };
            return View(menues);
        }
    }
}
