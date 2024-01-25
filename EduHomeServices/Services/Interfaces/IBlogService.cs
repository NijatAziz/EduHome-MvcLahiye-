using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Category;
using EduHomeServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogGetDto>> GetAllAsync();
        public Task<CommonResponse> CreateAsync(BlogPostDto dto);
        public Task<CommonResponse> UpdateAsync(int id, BlogPostDto dto);
        public Task<BlogGetDto> GetAsync(int id);

        Task<List<BlogGetDto>> GetBlogsBySearchTextAsync(string searchText);

        public Task RemovaAsync(int id);
    }
}
