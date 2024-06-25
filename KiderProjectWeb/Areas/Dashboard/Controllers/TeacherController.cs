using Business.Abstract;
using Business.Concrete;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
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
        public IActionResult Create(TeacherCreateDto teacher)
        {

            var result = _teacherService.Add(teacher, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                var errorResult = result as ErrorResult;
                if (errorResult != null)
                {
                    ModelState.Clear();
                    foreach (var error in errorResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                ViewData["Positions"] = _positionService.GetAll().Data;
                return View(teacher);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            var data = _teacherService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeacherUpdateDto teacher)
        {
            var result = _teacherService.Update(teacher, _env.WebRootPath);
            if (!result.IsSuccess)
            {
                var errorResult = result as ErrorResult;
                if (errorResult != null)
                {
                    ModelState.Clear();
                    foreach (var error in errorResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                ViewData["Positions"] = _positionService.GetAll().Data;
                return View(teacher);
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
