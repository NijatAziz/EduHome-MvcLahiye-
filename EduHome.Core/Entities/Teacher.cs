using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string FullName { get; set; }
        public string Proffesion { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public List<Social> Socials { get; set; }
        public List<TeacherFaculty> TeacherFaculties { get; set; } = null!;
        public List<TeacherHobby> TeacherHobbies { get; set; } = null!;
        //public List<Blog> Blogs { get; set; } = null!;
    }

}