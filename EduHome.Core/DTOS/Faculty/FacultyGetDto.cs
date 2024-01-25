using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Faculty
{
    public class FacultyGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
