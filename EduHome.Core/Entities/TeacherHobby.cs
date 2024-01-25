using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class TeacherHobby : BaseEntity
    {
        public int HobbyId { get; set; }
        public int TeacherId { get; set; }
        public Hobby Hobby { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
    }
}