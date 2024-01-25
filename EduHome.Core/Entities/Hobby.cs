using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Hobby : BaseEntity
    {
        public string HobbyName { get; set; }
        public List<TeacherHobby> TeacherHobbies { get; set; }
    }
}