using EduHome.Core.DTOS.Category;
using EduHome.Core.DTOS.Hobby;
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
    public class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;

        public HobbyService(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }
        public async Task CreateAsync(HobbyPostDto dto)
        {
            Hobby hobby = new()
            {
                HobbyName = dto.Name,
                CreatedAt = DateTime.Now
            };
            _hobbyRepository.AddAsync(hobby);
            _hobbyRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<HobbyGetDto>> GetAllAsync()
        {
            IEnumerable<HobbyGetDto> hobbies = await _hobbyRepository.GetQuery(x => !x.IsDeleted).
                 Include(x => x.TeacherHobbies).ThenInclude(x => x.Teacher).AsNoTrackingWithIdentityResolution()
                 .Select(x => new HobbyGetDto { Name = x.HobbyName, Id = x.ID, TeacherCount = x.TeacherHobbies.Where(x => !x.IsDeleted).Count() }).ToListAsync();
            return hobbies;
        }

        public async Task<HobbyGetDto> GetAsync(int id)
        {
            Hobby? hobby = await _hobbyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (hobby == null)
            {
                throw new ItemNotFoundExcpetion("Hobby is not Found");
            }

            HobbyGetDto hobbyGetDto = new()
            {
                Name = hobby.HobbyName,
                Id = hobby.ID,
                CreatedAt = hobby.CreatedAt
            };
            return hobbyGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Hobby hobby = await _hobbyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (hobby == null)
            {
                throw new ItemNotFoundExcpetion("Hobby is not Found");
            }
            hobby.IsDeleted = true;
            await _hobbyRepository.UpdateAsync(hobby);
            await _hobbyRepository.SaveChangesAsync();

        }

        public async Task UpdateAsync(int id, HobbyPostDto dto)
        {
            Hobby hobby = await _hobbyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (hobby == null)
            {
                throw new ItemNotFoundExcpetion("Hobby is not Found");
            }
            hobby.HobbyName = dto.Name;
            hobby.UpdatedDate = DateTime.Now;
            await _hobbyRepository.UpdateAsync(hobby);
            await _hobbyRepository.SaveChangesAsync();
        }
    }
}
