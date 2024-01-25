using EduHome.Core.DTOS.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface IFacultyService
    {
        public Task<IEnumerable<FacultyGetDto>> GetAllAsync();
        public Task CreateAsync(FacultyPostDto dto);
        public Task UpdateAsync(int id, FacultyPostDto dto);
        public Task<FacultyGetDto> GetAsync(int id);
        public Task RemovaAsync(int id);
    }
}
