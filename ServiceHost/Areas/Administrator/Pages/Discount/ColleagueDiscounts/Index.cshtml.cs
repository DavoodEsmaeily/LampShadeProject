using System.Collections.Generic;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administrator.Pages.Discount.ColleagueDiscounts
{
    public class IndexModel : PageModel
    {
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;
        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        public SelectList Products;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var colleagueDiscount = new DefineColleagueDiscount {
                Products =  _productApplication.GetProducts()
            };
            return Partial("Create" , colleagueDiscount);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            colleagueDiscount.Products = _productApplication.GetProducts();
            
            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnPostRemove(long id)
        {
            var result = _colleagueDiscountApplication.Remove(id);
            if(result.IsSucceded)
            return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnPostRestore(long id)
        {
            var result = _colleagueDiscountApplication.Restore(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


    }
}
