using EduHome.Core.DTOS.Blog;
using EduHome.Core.DTOS.Tag;
using EduHome.Data.DAl;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService TagService)
        {
            _tagService = TagService;
            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tagService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagPostDto dto)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            var response = await _tagService.CreateAsync(dto);

            if (response.StatusCode != 200)
            {

                ModelState.AddModelError("", response.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _tagService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TagPostDto dto)
        {
            if (!ModelState.IsValid)
            {

                return View(await _tagService.GetAsync(id));
            }
            var response = await _tagService.UpdateAsync(id, dto);

            if (response.StatusCode != 200)
            {

                ModelState.AddModelError("", response.Message);
                return View(await _tagService.GetAsync(id));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _tagService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
