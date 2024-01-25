using EduHome.Core.DTOS.Comment;
using EduHome.Core.DTOS.Course;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseCommentService _commentService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;

        public CoursesController(ICourseService courseService, ICourseCommentService commentService, ICategoryService categoryService, IBlogService blogService)
        {
            _courseService = courseService;
            _commentService = commentService;
            _categoryService = categoryService;
            _blogService = blogService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {

            return View(await _courseService.GetAllAsync(page));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var commentsWithUserNames = await _commentService.GetCommentsWithUserNamesAsync(id);
            var courseDto = await _courseService.GetAsync(id);

            if (courseDto == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.Blogs = await _blogService.GetAllAsync();
            ViewBag.Comments = commentsWithUserNames;

            return View(courseDto);
        }


    }
}
