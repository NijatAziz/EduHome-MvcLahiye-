using EduHome.Core.DTOS.Category;
using EduHome.Core.DTOS.Hobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IHobbyService
    {
        public Task<IEnumerable<HobbyGetDto>> GetAllAsync();
        public Task CreateAsync(HobbyPostDto dto);
        public Task UpdateAsync(int id, HobbyPostDto dto);
        public Task<HobbyGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);
    }
}
