﻿using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _env;
        public TeacherController(ITeacherService teacherService, IPositionService positionService, IWebHostEnvironment env)
        {
            _teacherService = teacherService;
            _positionService = positionService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _teacherService.GetAllTeacherWithDetails().Data;

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherCreateDto teacher, IFormFile photoUrl)
        {

            if (photoUrl != null)
            {
                var result = _teacherService.Add(teacher, photoUrl, _env.WebRootPath);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            var data = _teacherService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeacherUpdateDto teacher, IFormFile photoUrl)
        {
            var result = _teacherService.Update(teacher, photoUrl, _env.WebRootPath);


            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _teacherService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
