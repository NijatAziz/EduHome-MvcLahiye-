using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Course
{
    public class CoursePostDto
    {
        public string Title { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public string About { get; set; } = null!;
        public string HowToApply { get; set; } = null!;

        public string Certification { get; set; } = null!;
        public int FeatureId { get; set; }
        public int CategoryId { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
