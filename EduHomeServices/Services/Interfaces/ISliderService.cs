using EduHome.Core.DTOS.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface ISliderService
    {
        public Task<IEnumerable<SliderGetDto>> GetAllAsync();
        public Task CreateAsync(SliderPostDto dto);
        public Task UpdateAsync(int id, SliderPostDto dto);
        public Task<SliderGetDto> GetAsync(int id);
        public Task RemovaAsync(int id);
    }
}