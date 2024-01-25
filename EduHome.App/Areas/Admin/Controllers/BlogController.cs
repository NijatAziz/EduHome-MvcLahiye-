using EduHome.Core.DTOS.Blog;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ITeacherService _teacherService;

        public BlogController(IBlogService blogService, ITeacherService teacherService)
        {
            _blogService = blogService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Teacher = await _teacherService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teacher = await _teacherService.GetAllAsync();

                return View();
            }

            var response = await _blogService.CreateAsync(dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Teacher = await _teacherService.GetAllAsync();

                ModelState.AddModelError("", response.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Teacher = await _teacherService.GetAllAsync();
            return View(await _blogService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, BlogPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teacher = await _teacherService.GetAllAsync();

                return View(await _blogService.GetAsync(id));
            }
            var response = await _blogService.UpdateAsync(id, dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Teacher = await _teacherService.GetAllAsync();

                ModelState.AddModelError("", response.Message);
                return View(await _blogService.GetAsync(id));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _blogService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
