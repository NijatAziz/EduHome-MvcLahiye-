using EduHome.Core.DTOS.Author;
using EduHome.Core.DTOS.Hobby;
using EduHomeServices.Helper;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
       private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _authorService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _authorService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int id)
        {
            await _authorService.RemovaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                return View(await _authorService.GetAsync(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");

                SendMessageToTelegram.SendMessageToTelegrams($"error occurred: {ex.Message}");
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, AuthorPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _authorService.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
