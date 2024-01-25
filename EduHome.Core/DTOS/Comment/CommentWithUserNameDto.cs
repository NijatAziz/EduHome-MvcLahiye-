using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Comment
{
    public class CommentWithUserNameDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public CourseGetDto? Course { get; set; }
        public BlogGetDto? Blog { get; set; }

    }
}
