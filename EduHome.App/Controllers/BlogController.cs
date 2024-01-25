using EduHome.Core.DTOS.Blog;
using EduHome.Core.Repositories;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCommentService _commentService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IBlogCommentService commentService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _commentService = commentService;
        }
        public async Task<IActionResult> Index(string searchText)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();


            return View(await _blogService.GetBlogsBySearchTextAsync(searchText));
        }
        public async Task<IActionResult> Detail(int id)
        {
            var commentsWithUserNames = await _commentService.GetCommentsWithUserNamesAsync(id);
            var blogdto = await _blogService.GetAsync(id);

            if (blogdto == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            ViewBag.Blogs = await _blogService.GetAllAsync();
            ViewBag.Comments = commentsWithUserNames;

            return View(blogdto);
        }

    }
}