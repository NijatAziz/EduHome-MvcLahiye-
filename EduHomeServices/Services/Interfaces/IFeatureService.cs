using EduHome.Core.DTOS.Feature;
using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IFeatureService
    {
        public Task<IEnumerable<FeatureGetDto>> GetAllAsync();
        public Task CreateAsync(FeaturePostDto dto);
        public Task UpdateAsync(int id, FeaturePostDto dto);
        public Task<FeatureGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);
    }
}