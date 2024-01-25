using System;
using Microsoft.AspNetCore.Http;

namespace EduHome.Core.DTOS
{
    public record TeacherPostDto
    {
        public string FullName { get; set; } = null!;
        public string About { get; set; } = null!;
        public string Profession { get; set; }
        public List<int> FacultyId { get; set; }
        public List<int> HobbyId { get; set; }

        public List<string> Icons { get; set; } = null!;
        public List<string> Urls { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
    }
}

