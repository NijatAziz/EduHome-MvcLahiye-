using EduHome.Core.DTOS.Category;
using EduHome.Core.DTOS.Feature;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Course
{
    public class CourseGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public string About { get; set; } = null!;
        public string HowToApply { get; set; } = null!;

        public string Certification { get; set; } = null!;

        public FeatureGetDto FeatureGetDto { get; set; }
        public CategoryGetDto CategoryGetDto { get; set; }

        public string ImageFile { get; set; }
    }
}
