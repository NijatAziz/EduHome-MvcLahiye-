using EduHome.Core.DTOS;
using EduHome.Core.DTOS.Course;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly IFeatureService _featureService;

        public CourseController(ICourseService courseService, ICategoryService categoryService, IFeatureService featureService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _featureService = featureService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {

            return View(await _courseService.GetAllAsync(page));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Feature = await _featureService.GetAllAsync();
            ViewBag.Category = await _categoryService.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoursePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Feature = await _featureService.GetAllAsync();
                ViewBag.Category = await _categoryService.GetAllAsync();
                return View();
            }
            var response = await _courseService.CreateAsync(dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Feature = await _featureService.GetAllAsync();
                ViewBag.Category = await _categoryService.GetAllAsync();
                ModelState.AddModelError("", response.Message);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Feature = await _featureService.GetAllAsync();
            ViewBag.Category = await _categoryService.GetAllAsync();
            return View(await _courseService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, CoursePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Feature = await _featureService.GetAllAsync();
                ViewBag.Category = await _categoryService.GetAllAsync();
                return View(await _courseService.GetAsync(id));
            }
            var response = await _courseService.UpdateAsync(id, dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Feature = await _featureService.GetAllAsync();
                ViewBag.Category = await _categoryService.GetAllAsync();
                ModelState.AddModelError("", response.Message);
                return View(await _courseService.GetAsync(id));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _courseService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
