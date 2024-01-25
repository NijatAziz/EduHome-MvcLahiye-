using EduHome.Core.DTOS.Author;
using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Course;
using EduHome.Core.Entities;
using EduHomeServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorGetDto>> GetAllAsync();
        //public Task<PagginatedResponse<AuthorGetDto>> GetAllAsync(int id);

        public Task<CommonResponse> CreateAsync(AuthorPostDto dto);
        public Task<CommonResponse> UpdateAsync(int id, AuthorPostDto dto);
        public Task<AuthorGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);

    }
}
