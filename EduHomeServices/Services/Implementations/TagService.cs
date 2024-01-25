using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Responses;
using Microsoft.AspNetCore.Hosting;
using EduHome.Core.DTOS.Tag;
using Microsoft.EntityFrameworkCore;

namespace EduHomeServices.Services.Implementations
{
    public class TagService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ITagRepositroy _tagRepositroy;
        public TagService(IWebHostEnvironment env, ITagRepositroy tagRepositroy)
        {
            _env = env;
            _tagRepositroy = tagRepositroy;
        }
        public async Task<CommonResponse> CreateAsync(TagPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse();
            commonResponse.StatusCode = 200;

            Tag tag = new Tag
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now,

            };

            await _tagRepositroy.AddAsync(tag);
            await _tagRepositroy.SaveChangesAsync();
            return commonResponse;
        }

        public async Task<IEnumerable<TagGetDto>> GetAllAsync()
        {
            IEnumerable<TagGetDto> blogGetDtos = await _tagRepositroy.GetQuery(x => !x.IsDeleted)
               .AsNoTrackingWithIdentityResolution().Include(x => x.TagBlogs)
               .Select(x => new TagGetDto
               {
                   Name = x.Name,
               }).ToListAsync();


            return blogGetDtos;
        }

        public async Task<TagGetDto> GetAsync(int id)
        {

            var query = _tagRepositroy.GetQuery(x => !x.IsDeleted && x.ID == id).Include(x => x.TagBlogs);

            TagGetDto? blogGetDto = await query.Select(x => new TagGetDto
            {
                Name = x.Name
            }).FirstOrDefaultAsync();

            return blogGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Tag blog = await _tagRepositroy.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (blog is null)
            {
                throw new ItemNotFoundExcpetion("Blog Not Found");
            }

            blog.IsDeleted = true;
            await _tagRepositroy.UpdateAsync(blog);
            await _tagRepositroy.SaveChangesAsync();
        }

        public async Task<CommonResponse> UpdateAsync(int id, TagPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse();
            commonResponse.StatusCode = 200;
            Tag? blog = await _tagRepositroy.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (blog == null)
            {
                throw new ItemNotFoundExcpetion("Blog Not Found");
            }
            blog.Name = dto.Name;
           
            await _tagRepositroy.UpdateAsync(blog);
            await _tagRepositroy.SaveChangesAsync();
            return commonResponse;

        }
    }
}
