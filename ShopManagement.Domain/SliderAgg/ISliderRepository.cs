using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slider;
using System.Collections.Generic;

namespace ShopManagement.Domain.SliderAgg
{
    public interface ISliderRepository : IRepository<long , Slider>
    {
        EditSlider GetDetails(long id);
        List<SliderViewModel> GetSliders();
    }
}
