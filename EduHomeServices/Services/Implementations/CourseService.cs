using EduHome.Core.DTOS;
using EduHome.Core.DTOS.Category;
using EduHome.Core.DTOS.Course;
using EduHome.Core.DTOS.Feature;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Extentions;
using EduHomeServices.Responses;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IWebHostEnvironment _env;

        public CourseService(ICourseRepository courseRepository, IWebHostEnvironment env)
        {
            _courseRepository = courseRepository;
            _env = env;
        }

        public async Task<CommonResponse> CreateAsync(CoursePostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse
            {
                StatusCode = 200
            };

            if (dto.ImageFile == null)
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The field image is required";
                return commonResponse;
            }


            Course course = new()
            {
                Title = dto.Title,
                Desc = dto.Desc,
                About = dto.About,
                Certification = dto.Certification,
                HowToApply = dto.HowToApply,
                FeatureId = dto.FeatureId,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.Now
            };


            if (!dto.ImageFile.IsImage())
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "Image is not valid";
                return commonResponse;
            }

            if (dto.ImageFile.IsSizeOk(1))
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "Image  size is not valid";
                return commonResponse;
            }

            course.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/course");
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
            return commonResponse;
        }

        public async Task<PagginatedResponse<CourseGetDto>> GetAllAsync(int page = 1)
        {
            PagginatedResponse<CourseGetDto> pagginatedResponse = new PagginatedResponse<CourseGetDto>();
            pagginatedResponse.CurrentPage = page;
            var query = _courseRepository.GetQuery(x => !x.IsDeleted)
               .AsNoTrackingWithIdentityResolution()
               .Include(x => x.Category)
               .Include(x => x.Feature);
            pagginatedResponse.TotalPages = (int)Math.Ceiling((double)query.Count() / 3);

            pagginatedResponse.Items = await query.Skip((page - 1) * 3)
               .Take(3)
               .Select(x =>
               new CourseGetDto
               {
                   Title = x.Title,
                   Id = x.ID,
                   ImageFile = x.Image,
                   Desc = x.Desc
               })
               .ToListAsync();

            return pagginatedResponse;
        }

        public async Task<CourseGetDto> GetAsync(int id)
        {
            var query = _courseRepository.GetQuery(x => !x.IsDeleted).Include(x => x.Category).Include(x => x.Feature);

            CourseGetDto? courseGetDto = await query.Select(x => new CourseGetDto
            {
                Id = x.ID,
                Title = x.Title,
                Desc = x.Desc,
                ImageFile = x.Image,
                About = x.About,
                Certification = x.Certification,
                HowToApply = x.HowToApply,
                CategoryGetDto = new CategoryGetDto { Name = x.Category.Name, Id = x.Category.ID },
                FeatureGetDto = new FeatureGetDto { Starts = x.Feature.Starts, CourseFee = x.Feature.CourseFee, Id = x.ID }

            }).FirstOrDefaultAsync();

            return courseGetDto;
        }

        public async Task RemoveAsync(int id)
        {
            Course course = await _courseRepository.GetAsync(x => x.ID == id && !x.IsDeleted);

            if (course is null)
            {
                throw new ItemNotFoundExcpetion("Course is not found");
            }
            course.IsDeleted = true;
            await _courseRepository.UpdateAsync(course);
            await _courseRepository.SaveChangesAsync();
        }

        public async Task<CommonResponse> UpdateAsync(int id, CoursePostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse
            {
                StatusCode = 200
            };

            Course? course = await _courseRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (course == null)
            {
                throw new ItemNotFoundExcpetion("Course Not Found");
            }

            course.Title = dto.Title;
            course.Desc = dto.Desc;
            course.CategoryId = dto.CategoryId;
            course.FeatureId = dto.FeatureId;
            course.UpdatedDate = DateTime.Now;
            course.About = dto.About;
            course.Certification = dto.Certification;
            course.HowToApply = dto.HowToApply;
            if (dto.ImageFile != null)
            {
                if (!dto.ImageFile.IsImage())
                {
                    commonResponse.StatusCode = 400;
                    commonResponse.Message = "Image is not valid";
                    return commonResponse;
                }

                if (dto.ImageFile.IsSizeOk(1))
                {
                    commonResponse.StatusCode = 400;
                    commonResponse.Message = "Image  size is not valid";
                    return commonResponse;
                }
                FileExtention.RemoveFile(_env.WebRootPath, "img/course", course.Image);
                course.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/course");
            }

            await _courseRepository.UpdateAsync(course);
            await _courseRepository.SaveChangesAsync();
            return commonResponse;
        }
    }
}
