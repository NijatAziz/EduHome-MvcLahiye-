using EduHome.Core.DTOS.Slider;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sliderService.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _sliderService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _sliderService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _sliderService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SliderPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _sliderService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

    }
}