using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Blog
{
    public class BlogGetDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }

        public TeacherGetDto TeacherGetDto { get; set; } = null!;
        public int CommentCount { get; set; }
        public DateTime Date { get; set; }
    }
}
