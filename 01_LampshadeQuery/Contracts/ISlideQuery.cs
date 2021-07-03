using System.Collections.Generic;

namespace _01_LampshadeQuery.Contracts
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
