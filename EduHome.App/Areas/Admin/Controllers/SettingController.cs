using EduHome.Core.DTOS.Setting;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _settingService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _settingService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _settingService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _settingService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SettingPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _settingService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
    }
}