using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Course;
using EduHome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Comment
{
    public class CommentGetDto
    {
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public BlogGetDto? Blog { get; set; }
        public CourseGetDto? Course { get; set; }
    }
}
