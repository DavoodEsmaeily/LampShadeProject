using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slider
{
  public  interface ISliderApplication
    {
        OperationResult Create(CreateSlider command);
        OperationResult Edit(EditSlider command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlider GetDetails(long id);
        List<SliderViewModel> GetSliders();
    }
}
