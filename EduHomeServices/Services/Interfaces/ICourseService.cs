using EduHome.Core.DTOS;
using EduHome.Core.DTOS.Course;
using EduHomeServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<PagginatedResponse<CourseGetDto>> GetAllAsync(int page = 1);

        public Task<CommonResponse> CreateAsync(CoursePostDto dto);

        public Task RemoveAsync(int id);

        public Task<CommonResponse> UpdateAsync(int id, CoursePostDto dto);
        public Task<CourseGetDto> GetAsync(int id);
    }
}
