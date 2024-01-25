using EduHome.Core.DTOS.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryGetDto>> GetAllAsync();
        public Task CreateAsync(CategoryPostDto dto);
        public Task UpdateAsync(int id, CategoryPostDto dto);
        public Task<CategoryGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);
    }
}
