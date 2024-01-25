using EduHome.Core.DTOS.Faculty;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _facultyService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacultyPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _facultyService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _facultyService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _facultyService.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FacultyPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _facultyService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
