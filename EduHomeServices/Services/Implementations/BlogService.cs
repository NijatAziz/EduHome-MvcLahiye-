using EduHome.Core.DTOS;
using EduHome.Core.DTOS.Blog;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Extentions;
using EduHomeServices.Responses;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IBlogRepository _blogRepository;
        public BlogService(IWebHostEnvironment env, IBlogRepository blogRepository)
        {
            _env = env;
            _blogRepository = blogRepository;
        }
        public async Task<CommonResponse> CreateAsync(BlogPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse();
            commonResponse.StatusCode = 200;

            Blog blog = new Blog
            {
                TeacherId = dto.TeacherId,
               // AuthorId=dto.AuthorId,
                Desc = dto.Desc,
                Title = dto.Title,
                Comments = new List<Comment>(),
                CreatedAt = DateTime.Now,

            };

            if (dto.ImageFile == null)
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The field image is required";
                return commonResponse;
            }

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

            blog.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/blog");

            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveChangesAsync();
            return commonResponse;
        }

        public async Task<IEnumerable<BlogGetDto>> GetAllAsync()
        {
            IEnumerable<BlogGetDto> blogGetDtos = await _blogRepository.GetQuery(x => !x.IsDeleted)
               .AsNoTrackingWithIdentityResolution().Include(x => x.Comments).Include(x => x.Teacher)
               .Select(x => new BlogGetDto
               {
                   Id = x.ID,
                   Title = x.Title,
                   Desc = x.Desc,
                   Image = x.Image,
                   TeacherGetDto = new TeacherGetDto { FullName = x.Teacher.FullName, Image = x.Teacher.Image },
                   Date = x.CreatedAt,
                   CommentCount = x.Comments.Where(x => !x.IsDeleted).Count()
               }).ToListAsync();


            return blogGetDtos;
        }

        public async Task<BlogGetDto> GetAsync(int id)
        {

            var query = _blogRepository.GetQuery(x => !x.IsDeleted && x.ID == id).Include(x => x.Comments)
             .Include(x => x.Teacher);

            BlogGetDto? blogGetDto = await query.Select(x => new BlogGetDto
            {
                Id = x.ID,
                Title = x.Title,
                Desc = x.Desc,
                Image = x.Image,
                TeacherGetDto = new TeacherGetDto { FullName = x.Teacher.FullName, Id = x.Teacher.ID },
                CommentCount = x.Comments.Count,
                Date = x.CreatedAt
            }).FirstOrDefaultAsync();
            return blogGetDto;
        }

        public async Task<List<BlogGetDto>> GetBlogsBySearchTextAsync(string searchText)
        {
           if (string.IsNullOrEmpty(searchText))
            {
                List<BlogGetDto> blogGetDtos = await _blogRepository.GetQuery(x => !x.IsDeleted)
                   .AsNoTrackingWithIdentityResolution().Include(x => x.Comments).Include(x => x.Teacher)
                   .Select(x => new BlogGetDto
                   {
                       Id = x.ID,
                       Title = x.Title,
                       Desc = x.Desc,
                       Image = x.Image,
                       TeacherGetDto = new TeacherGetDto { FullName = x.Teacher.FullName, Image = x.Teacher.Image },
                       Date = x.CreatedAt,
                       CommentCount = x.Comments.Where(x => !x.IsDeleted).Count()
                   }).ToListAsync();

                return blogGetDtos;
            }

            return await _blogRepository.GetQuery(x => !x.IsDeleted).AsNoTrackingWithIdentityResolution()
                .Include(x => x.Comments).Include(x => x.Teacher)
                 .Select(x => new BlogGetDto
                 {
                     Id = x.ID,
                     Title = x.Title,
                     Desc = x.Desc,
                     Image = x.Image,
                     TeacherGetDto = new TeacherGetDto { FullName = x.Teacher.FullName, Image = x.Teacher.Image },
                     Date = x.CreatedAt,
                     CommentCount = x.Comments.Where(x => !x.IsDeleted).Count()

                 }).Where(m => m.Title.ToLower().Contains(searchText.ToLower())).ToListAsync();
        }

        public async Task RemovaAsync(int id)
        {
            Blog blog = await _blogRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (blog is null)
            {
                throw new ItemNotFoundExcpetion("Blog Not Found");
            }

            blog.IsDeleted = true;
            await _blogRepository.UpdateAsync(blog);
            await _blogRepository.SaveChangesAsync();
        }

        public async Task<CommonResponse> UpdateAsync(int id, BlogPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse();
            commonResponse.StatusCode = 200;
            Blog? blog = await _blogRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (blog == null)
            {
                throw new ItemNotFoundExcpetion("Blog Not Found");
            }
            blog.Title = dto.Title;
            blog.Desc = dto.Desc;
            blog.UpdatedDate = DateTime.Now;
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

                blog.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/blog");
            }
            await _blogRepository.UpdateAsync(blog);
            await _blogRepository.SaveChangesAsync();
            return commonResponse;

        }
    }
}
