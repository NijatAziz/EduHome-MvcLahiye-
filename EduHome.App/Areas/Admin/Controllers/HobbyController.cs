using EduHome.Core.DTOS.Category;
using EduHome.Core.DTOS.Hobby;
using EduHomeServices.Helper;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HobbyController : Controller
    {
        private readonly IHobbyService _hobbyService;

        public HobbyController(IHobbyService hobbyService)
        {
            _hobbyService = hobbyService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _hobbyService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HobbyPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _hobbyService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _hobbyService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                return View(await _hobbyService.GetAsync(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");

                SendMessageToTelegram.SendMessageToTelegrams($"Hata oluştu: {ex.Message}");
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, HobbyPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _hobbyService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
