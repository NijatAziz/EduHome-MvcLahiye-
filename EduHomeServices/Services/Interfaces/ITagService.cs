using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Tag;
using EduHomeServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface ITagService
    {
        public Task<IEnumerable<TagGetDto>> GetAllAsync();
        public Task<CommonResponse> CreateAsync(TagPostDto dto);
        public Task<CommonResponse> UpdateAsync(int id, TagPostDto dto);
        public Task<TagGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);
    }
}
