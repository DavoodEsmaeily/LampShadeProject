using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public SelectList ProductCategories;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var product = new CreateProduct {
                ProductCategories =  _productCategoryApplication.GetProductCategories()
            };
            return Partial("Create" , product);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var product = _productApplication.GetDetails(id);
            product.ProductCategories = _productCategoryApplication.GetProductCategories();
            
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnPostInStock(long id)
        {
            var result = _productApplication.InStock(id);
            if(result.IsSucceded)
            return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnPostNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


    }
}
