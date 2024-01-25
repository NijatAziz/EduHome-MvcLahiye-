﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.DTOS.Slider
{
    public class SliderPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}