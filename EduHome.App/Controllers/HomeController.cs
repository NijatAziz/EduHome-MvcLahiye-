using EduHome.Core.Entities;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EduHome.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IBlogService _blogService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;

        public HomeController(ISliderService sliderService, IBlogService blogService, ITeacherService teacherService, ICourseService courseService)
        {
            _sliderService = sliderService;
            _blogService = blogService;
            _teacherService = teacherService;
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            var teachers = await _teacherService.GetAllAsync();
            var course = await _courseService.GetAllAsync();
            ViewBag.Blog = blogs;
            ViewBag.Teacher = teachers;
            ViewBag.Course = course;

            return View(await _sliderService.GetAllAsync());
        }

    }
}