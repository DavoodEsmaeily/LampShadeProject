using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slider;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SliderApplication : ISliderApplication
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderApplication(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public OperationResult Create(CreateSlider command)
        {
            var operation = new OperationResult();

            var slider = new Slider
                (command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text,  command.BtnText , command.Link);
            _sliderRepository.Create(slider);
            _sliderRepository.SaveChanges();

            return operation.Succeded();
        }

        public OperationResult Edit(EditSlider command)
        {
            var operation = new OperationResult();
            var slider = _sliderRepository.Get(command.Id);

            if (slider == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);            

            slider.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText , command.Link);
            _sliderRepository.SaveChanges();

            return operation.Succeded();
        }

        public EditSlider GetDetails(long id)
        {
            return _sliderRepository.GetDetails(id);
        }

        public List<SliderViewModel> GetSliders()
        {
            return _sliderRepository.GetSliders();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slider = _sliderRepository.Get(id);

            if (slider == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slider.Remove();
            _sliderRepository.SaveChanges();

            return operation.Succeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slider = _sliderRepository.Get(id);

            if (slider == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slider.Restore();
            _sliderRepository.SaveChanges();

            return operation.Succeded();
        }
    }
}
