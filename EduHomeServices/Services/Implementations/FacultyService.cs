using EduHome.Core.DTOS.Faculty;
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
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }
        public async Task CreateAsync(FacultyPostDto dto)
        {
            Faculty faculty = new()
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now
            };
            _facultyRepository.AddAsync(faculty);
            _facultyRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FacultyGetDto>> GetAllAsync()
        {
            IEnumerable<FacultyGetDto> faculties = await _facultyRepository.GetQuery(x => !x.IsDeleted).
               Include(x => x.TeacherFaculties).ThenInclude(x => x.Teacher).AsNoTrackingWithIdentityResolution()
               .Select(x => new FacultyGetDto { Name = x.Name, Id = x.ID, TeacherCount = x.TeacherFaculties.Where(x => !x.IsDeleted).Count() }).ToListAsync();
            return faculties;
        }

        public async Task<FacultyGetDto> GetAsync(int id)
        {

            Faculty? faculty = await _facultyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (faculty == null)
            {
                throw new ItemNotFoundExcpetion("Faculty is not Found");
            }

            FacultyGetDto facultyGetDto = new()
            {
                Name = faculty.Name,
                Id = faculty.ID,
                CreatedAt = faculty.CreatedAt
            };
            return facultyGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Faculty faculty = await _facultyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (faculty == null)
            {
                throw new ItemNotFoundExcpetion("Faculty is not Found");
            }
            faculty.IsDeleted = true;
            await _facultyRepository.UpdateAsync(faculty);
            await _facultyRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, FacultyPostDto dto)
        {
            Faculty faculty = await _facultyRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (faculty == null)
            {
                throw new ItemNotFoundExcpetion("Faculty is not Found");
            }
            faculty.Name = dto.Name;
            faculty.UpdatedDate = DateTime.Now;
            await _facultyRepository.UpdateAsync(faculty);
            await _facultyRepository.SaveChangesAsync();
        }
    }

}
