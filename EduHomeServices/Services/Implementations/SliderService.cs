using EduHome.Core.DTOS.Setting;
using EduHome.Core.DTOS.Slider;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Extentions;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    internal class SliderService : ISliderService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISliderRepository _sliderRepository;

        public SliderService(IWebHostEnvironment env, ISliderRepository sliderRepository)
        {
            _env = env;
            _sliderRepository = sliderRepository;
        }
        public async Task CreateAsync(SliderPostDto dto)
        {
            Slider slider = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.Now
            };

            string mainImage = dto.ImageUrl.SaveFile(_env.WebRootPath, "img/slider");

            slider.ImageUrl = mainImage;

            await _sliderRepository.AddAsync(slider);
            await _sliderRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderGetDto>> GetAllAsync()
        {
            IEnumerable<SliderGetDto> sliders = await _sliderRepository.GetQuery(x => !x.IsDeleted)
            .Select(x => new SliderGetDto { Title = x.Title, Id = x.ID, Description = x.Description, CurrentImage = x.ImageUrl }).ToListAsync();
            return sliders;
        }

        public async Task<SliderGetDto> GetAsync(int id)
        {
            Slider? slider = await _sliderRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (slider == null)
            {
                throw new ItemNotFoundExcpetion("Slider is not Found");
            }

            SliderGetDto sliderGetDto = new()
            {
                Title = slider.Title,
                Id = slider.ID,
                Description = slider.Description,
                CurrentImage = slider.ImageUrl,
            };
            return sliderGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Slider slider = await _sliderRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (slider == null)
            {
                throw new ItemNotFoundExcpetion("Slider is not Found");
            }
            FileExtention.RemoveFile(_env.WebRootPath, "img/slider", slider.ImageUrl);


            slider.IsDeleted = true;

            await _sliderRepository.UpdateAsync(slider);
            await _sliderRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SliderPostDto dto)
        {
            Slider slider = await _sliderRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (slider == null)
            {
                throw new ItemNotFoundExcpetion("slider is not Found");
            }
            slider.Title = dto.Title;
            slider.Description = dto.Description;
            slider.UpdatedDate = DateTime.Now;
            string mainImage = dto.ImageUrl.SaveFile(_env.WebRootPath, "img/slider");

            slider.ImageUrl = mainImage;

            await _sliderRepository.UpdateAsync(slider);
            await _sliderRepository.SaveChangesAsync();
        }
    }
}