using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slider;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Sliders
{
    public class IndexModel : PageModel
    {
        public List<SliderViewModel> Sliders;
        private readonly ISliderApplication _sliderApplication;

        public IndexModel(ISliderApplication sliderApplication)
        {
            _sliderApplication = sliderApplication;
        }

        public void OnGet()
        {
            Sliders = _sliderApplication.GetSliders();
        }

        public IActionResult OnGetCreate()
        {
            var slider = new CreateSlider {
            };
            return Partial("Create" , slider);
        }

        public JsonResult OnPostCreate(CreateSlider command)
        {
            var result = _sliderApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var slider = _sliderApplication.GetDetails(id);
            
            return Partial("Edit", slider);
        }

        public JsonResult OnPostEdit(EditSlider command)
        {
            var result = _sliderApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnPostRemove(long id)
        {
            var result = _sliderApplication.Remove(id);
            if(result.IsSucceded)
            return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnPostRestore(long id)
        {
            var result = _sliderApplication.Restore(id);
            if (result.IsSucceded)
                return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


    }
}
