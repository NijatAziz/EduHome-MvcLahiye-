using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
