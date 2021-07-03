using _01_LampshadeQuery.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SliderViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slids = _slideQuery.GetSlides();
            return View(slids);
        }
    }
}
