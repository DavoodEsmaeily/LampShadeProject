using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ServiceHost.Areas.Administrator.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;
        public SelectList Products;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _productPictureApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var product = new CreateProductPicture {
                Products =  _productApplication.GetProducts()
            };
            return Partial("Create" , product);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var product = _productPictureApplication.GetDetails(id);
            product.Products = _productApplication.GetProducts();
            
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnPostRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);
            if(result.IsSucceded)
            return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnPostRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


    }
}
