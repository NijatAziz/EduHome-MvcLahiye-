using EduHome.Core.Entities.BaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Blog? Blog { get; set; }
        public int? BlogId { get; set; }

        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}