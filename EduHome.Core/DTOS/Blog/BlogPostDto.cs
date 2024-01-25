using EduHome.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Blog
{
    public class BlogPostDto
    {
        public string Desc { get; set; }
        public string Title { get; set; }

        public int TeacherId { get; set; }
        public bool Okay { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
