using EduHome.Core.DTOS;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
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
    public class TeacherService : ITeacherService
    {

        readonly ITeacherRepository _teacherRepository;
        readonly IWebHostEnvironment _env;

        public TeacherService(ITeacherRepository teacherRepository, IWebHostEnvironment env)
        {
            _teacherRepository = teacherRepository;
            _env = env;
        }
        public async Task<CommonResponse> CreateAsync(TeacherPostDto dto)
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

            if (dto.Icons == null || dto.Urls == null || dto.Icons.Count() != dto.Urls.Count())
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The socihal network is not valid";
                return commonResponse;
            }

            if (dto.Icons.Any(x => string.IsNullOrWhiteSpace(x)) || dto.Urls.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The socihal network is not valid";
                return commonResponse;
            }

            Teacher teacher = new()
            {
                FullName = dto.FullName,
                Proffesion = dto.Profession,
                About = dto.About,
                Socials = new List<Social>(),
                TeacherFaculties = new List<TeacherFaculty>(),
                TeacherHobbies = new List<TeacherHobby>(),
                CreatedAt = DateTime.Now
            };
            CreateSochial(dto, teacher);

            for (int i = 0; i < dto.FacultyId.Count(); i++)
            {
                teacher.TeacherFaculties.Add(new TeacherFaculty
                {
                    Teacher = teacher,
                    FacultyId = dto.FacultyId[i],
                });
            }
            for (int i = 0; i < dto.HobbyId.Count(); i++)
            {
                teacher.TeacherHobbies.Add(new TeacherHobby
                {
                    Teacher = teacher,
                    HobbyId = dto.HobbyId[i],
                });
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

            teacher.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/teacher");
            await _teacherRepository.AddAsync(teacher);
            await _teacherRepository.SaveChangesAsync();
            return commonResponse;
        }

        public async Task<PagginatedResponse<TeacherGetDto>> GetAllAsync(int page = 1)
        {
            PagginatedResponse<TeacherGetDto> pagginatedResponse = new PagginatedResponse<TeacherGetDto>();
            pagginatedResponse.CurrentPage = page;
            var query = _teacherRepository.GetQuery(x => !x.IsDeleted)
               .AsNoTrackingWithIdentityResolution()
               .Include(x => x.Socials)
               .Include(x => x.TeacherHobbies).ThenInclude(x => x.Hobby)
               .Include(x => x.TeacherFaculties).ThenInclude(x => x.Faculty);
            pagginatedResponse.TotalPages = (int)Math.Ceiling((double)query.Count() / 3);

            pagginatedResponse.Items = await query.Skip((page - 1) * 3)
               .Take(3)
               .Select(x =>
               new TeacherGetDto
               {
                   FullName = x.FullName,
                   Id = x.ID,
                   Image = x.Image,
                   About = x.About,
                   Profession = x.Proffesion
               })
               .ToListAsync();

            return pagginatedResponse;
        }

        public async Task<TeacherGetDto> GetAsync(int id)
        {
            var query = _teacherRepository.GetQuery(x => !x.IsDeleted && x.ID == id).Include(x => x.Socials)
                .Include(x => x.TeacherHobbies).ThenInclude(x => x.Hobby)
               .Include(x => x.TeacherFaculties).ThenInclude(x => x.Faculty);

            TeacherGetDto? teacherGetDto = await query.Select(x => new TeacherGetDto
            {
                Id = x.ID,
                FullName = x.FullName,
                About = x.About,
                Icons = x.Socials.Select(x => x.Key).ToList(),
                Urls = x.Socials.Select(x => x.Value).ToList(),
                Profession = x.Proffesion,
                Image = x.Image,
                TeacherFaculties = x.TeacherFaculties,
                TeacherHobbies = x.TeacherHobbies
            }).FirstOrDefaultAsync();
            return teacherGetDto;
        }

        public async Task RemoveAsync(int id)
        {
            Teacher? teacher = await _teacherRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (teacher == null)
            {
                throw new ItemNotFoundExcpetion("teacher Not Found");
            }
            teacher.IsDeleted = true;
            await _teacherRepository.UpdateAsync(teacher);
            await _teacherRepository.SaveChangesAsync();
        }

        public async Task<CommonResponse> UpdateAsync(int id, TeacherPostDto dto)
        {
            CommonResponse commonResponse = new CommonResponse
            {
                StatusCode = 200
            };
            if (dto.Icons == null || dto.Urls == null || dto.Icons.Count() != dto.Urls.Count())
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The socihal network is not valid";
                return commonResponse;
            }

            if (dto.Icons.Any(x => string.IsNullOrWhiteSpace(x)) || dto.Urls.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                commonResponse.StatusCode = 400;
                commonResponse.Message = "The socihal network is not valid";
                return commonResponse;
            }




            Teacher? teacher = await _teacherRepository.GetAsync(x => !x.IsDeleted && x.ID == id, "SocialNetworks");

            if (teacher == null)
            {
                throw new ItemNotFoundExcpetion("Teacher Not Found");
            }

            teacher.FullName = dto.FullName;
            teacher.About = dto.About;
            teacher.Proffesion = dto.Profession;
            teacher.Socials.Clear();
            teacher.TeacherFaculties.Clear();
            teacher.UpdatedDate = DateTime.Now;
            for (int i = 0; i < dto.FacultyId.Count(); i++)
            {
                teacher.TeacherFaculties.Add(new TeacherFaculty
                {
                    Teacher = teacher,
                    FacultyId = dto.FacultyId[i],
                });
            }
            teacher.TeacherHobbies.Clear();

            for (int i = 0; i < dto.HobbyId.Count(); i++)
            {
                teacher.TeacherHobbies.Add(new TeacherHobby
                {
                    Teacher = teacher,
                    HobbyId = dto.HobbyId[i],
                });
            }

            CreateSochial(dto, teacher);

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
                FileExtention.RemoveFile(_env.WebRootPath, "img/teacher", teacher.Image);
                teacher.Image = dto.ImageFile.SaveFile(_env.WebRootPath, "img/teacher");
            }

            await _teacherRepository.UpdateAsync(teacher);
            await _teacherRepository.SaveChangesAsync();
            return commonResponse;
        }




        private void CreateSochial(TeacherPostDto dto, Teacher teacher)
        {
            for (int i = 0; i < dto.Icons.Count(); i++)
            {
                Social socialNetwork = new Social
                {
                    Teacher = teacher,
                    Key = dto.Icons[i],
                    Value = dto.Urls[i]
                };
                teacher.Socials.Add(socialNetwork);
            }
        }

    }
}
