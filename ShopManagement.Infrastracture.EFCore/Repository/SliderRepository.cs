using _0_Framework.Infrastracture;
using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastracture.EFCore.Repository
{
    public class SliderRepository : RepositoryBase<long, Slider>, ISliderRepository
    {
        private readonly ShopContext _shopContext;

        public SliderRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSlider GetDetails(long id)
        {
            return _shopContext.Sliders.Select(x => new EditSlider
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Text = x.Text,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SliderViewModel> GetSliders()
        {
            return _shopContext.Sliders.Select(x => new SliderViewModel
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = x.IsDeleted,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                Id = x.Id
            }).OrderByDescending(x => x.Id).ToList();
           
        }
    }
}
