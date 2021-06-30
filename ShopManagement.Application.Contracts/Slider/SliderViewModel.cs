namespace ShopManagement.Application.Contracts.Slider
{
    public class SliderViewModel
    {
        public string Picture { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public string CreationDate { get; set; }
        public object Id { get; set; }
    }

}
