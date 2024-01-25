using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Core.DTOS;
using EduHomeServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.App.areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IHobbyService _hobbyService;
        private readonly IFacultyService _facultyService;

        public TeacherController(ITeacherService teacherService, IHobbyService hobbyService, IFacultyService facultyService)
        {
            _teacherService = teacherService;
            _hobbyService = hobbyService;
            _facultyService = facultyService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {

            return View(await _teacherService.GetAllAsync(page));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Hobby = await _hobbyService.GetAllAsync();
            ViewBag.Faculty = await _facultyService.GetAllAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Hobby = await _hobbyService.GetAllAsync();
                ViewBag.Faculty = await _facultyService.GetAllAsync();
                return View();
            }
            var response = await _teacherService.CreateAsync(dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Hobby = await _hobbyService.GetAllAsync();
                ViewBag.Faculty = await _facultyService.GetAllAsync();
                ModelState.AddModelError("", response.Message);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Hobby = await _hobbyService.GetAllAsync();
            ViewBag.Faculty = await _facultyService.GetAllAsync();
            return View(await _teacherService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TeacherPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Hobby = await _hobbyService.GetAllAsync();
                ViewBag.Faculty = await _facultyService.GetAllAsync();
                return View(await _teacherService.GetAsync(id));
            }
            var response = await _teacherService.UpdateAsync(id, dto);

            if (response.StatusCode != 200)
            {
                ViewBag.Hobby = await _hobbyService.GetAllAsync();
                ViewBag.Faculty = await _facultyService.GetAllAsync();
                ModelState.AddModelError("", response.Message);
                return View(await _teacherService.GetAsync(id));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _teacherService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}

