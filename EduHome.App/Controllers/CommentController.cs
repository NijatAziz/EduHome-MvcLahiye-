using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
