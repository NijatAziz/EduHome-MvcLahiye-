using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
