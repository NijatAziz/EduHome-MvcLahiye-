using EduHome.Core.DTOS.Feature;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _featureService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeaturePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _featureService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _featureService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _featureService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, FeaturePostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _featureService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
    }
}