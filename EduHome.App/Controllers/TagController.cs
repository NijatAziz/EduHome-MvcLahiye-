using EduHome.Core.DTOS.Tag;
using EduHome.Data.DAl;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class TagController : Controller
    {
        readonly EduHomeDbContext _dbContext;

        public TagController(EduHomeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<TagGetDto> TagGetDtos = _dbContext.Tags
                .Where(x => !x.IsDeleted).Select(x => new TagGetDto { Name = (string)x.Name }).AsEnumerable();
            return Json(TagGetDtos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Create (TagPostDto tag)
        {
            if(!ModelState.IsValid)
            {
                return View(tag);
            }
            return View();
        }
    }
}
