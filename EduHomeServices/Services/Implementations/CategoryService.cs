using EduHome.Core.DTOS.Category;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(CategoryPostDto dto)
        {
            Category category = new()
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAllAsync()
        {
            IEnumerable<CategoryGetDto> Categorys = await _categoryRepository.GetQuery(x => !x.IsDeleted)
               .Include(x => x.Course)
              .AsNoTrackingWithIdentityResolution().Select(x => new CategoryGetDto { Name = x.Name, Id = x.ID, CreatedAt = x.CreatedAt, CourceCount = x.Course.Where(x => !x.IsDeleted).Count() })
              .ToListAsync();
            return Categorys;
        }

        public async Task<CategoryGetDto> GetAsync(int id)
        {
            Category? Category = await _categoryRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (Category == null)
            {
                throw new ItemNotFoundExcpetion("Category Not Found");
            }

            CategoryGetDto categoryGetDto = new CategoryGetDto
            {
                CreatedAt = Category.CreatedAt,
                Id = Category.ID,
                Name = Category.Name
            };
            return categoryGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Category? Category = await _categoryRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (Category == null)
            {
                throw new ItemNotFoundExcpetion("Category Not Found");
            }
            Category.IsDeleted = true;
            await _categoryRepository.UpdateAsync(Category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryPostDto dto)
        {
            Category? Category = await _categoryRepository.GetAsync(x => !x.IsDeleted && x.ID == id);

            if (Category == null)
            {
                throw new ItemNotFoundExcpetion("Category Not Found");
            }

            Category.Name = dto.Name;
            Category.UpdatedDate = DateTime.Now;
            await _categoryRepository.UpdateAsync(Category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
