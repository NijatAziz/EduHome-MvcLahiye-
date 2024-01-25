using EduHome.Core.Entities;
using System;
namespace EduHome.Core.DTOS
{

    public record TeacherGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string About { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public List<string> Icons { get; set; } = null!;
        public List<string> Urls { get; set; } = null!;
        public string Image { get; set; } = null!;
        public List<TeacherHobby> TeacherHobbies { get; set; } = null!;
        public List<TeacherFaculty> TeacherFaculties { get; set; } = null!;


    }
}

