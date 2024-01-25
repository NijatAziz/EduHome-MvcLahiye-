using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _teacherService.GetAllAsync());
        }

        public async Task<IActionResult> Detail(int id)
        {
            return View(await _teacherService.GetAsync(id));
        }
    }
}