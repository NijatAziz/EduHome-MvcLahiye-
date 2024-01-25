using EduHome.Core.DTOS;
using EduHome.Core.DTOS.Author;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Responses;
using EduHomeServices.Services.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EduHomeServices.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


        public async Task<CommonResponse> CreateAsync(AuthorPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse
            {
                StatusCode = 200
            };
            Author author = new()
            {
                FullName = dto.Name,

            };
            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveChangesAsync();
            return commonResponse;

        }

        //public async Task<PagginatedResponse<AuthorGetDto>> GetAllAsync(int page = 1)
        //{
        //    PagginatedResponse<AuthorGetDto> pagginatedResponse = new PagginatedResponse<AuthorGetDto>();
        //    pagginatedResponse.CurrentPage = page;
        //    var query = _authorRepository.GetQuery(x => !x.IsDeleted)
        //       .AsNoTrackingWithIdentityResolution();

        //    pagginatedResponse.TotalPages = (int)Math.Ceiling((double)query.Count() / 3);

        //   pagginatedResponse.Items = await query.Skip((page - 1) * 3)
        //       .Take(3)
        //       .Select(x =>
        //       new AuthorGetDto
        //       {
        //           Name = x.FullName,

        //       })
        //       .ToListAsync();
        //     return pagginatedResponse;
        //}

        public async Task<IEnumerable<AuthorGetDto>> GetAllAsync()
        {
            IEnumerable<AuthorGetDto> authorGetDtos = await _authorRepository.GetQuery(x => !x.IsDeleted)
          .AsNoTrackingWithIdentityResolution()
          .Select(x => new AuthorGetDto
          {
              Name = x.FullName,
              Id=x.ID
          }).ToListAsync();

            return authorGetDtos;
        }

        public async Task<AuthorGetDto> GetAsync(int id)
        {
            Author? Author = await _authorRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (Author == null)
            {
                throw new ItemNotFoundExcpetion("Author Not Found");
            }
            AuthorGetDto authorGetDto = new AuthorGetDto();
            {
                id = Author.ID;

            };
            return authorGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Author? Author = await _authorRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (Author == null)
            {
                throw new ItemNotFoundExcpetion("Author Not Found");
            }
            Author.IsDeleted = true;
            await _authorRepository.UpdateAsync(Author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task<CommonResponse> UpdateAsync(int id, AuthorPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse
            {
                StatusCode = 200
            };

            Author? author = await _authorRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (author == null)
            {
                throw new ItemNotFoundExcpetion("Author Not Found");
            }

            author.FullName = dto.Name;


            await _authorRepository.UpdateAsync(author);
            await _authorRepository.SaveChangesAsync();

            return commonResponse;
        }


    }
}
