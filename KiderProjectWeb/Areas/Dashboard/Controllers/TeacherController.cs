using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IPositionService _positionService;
        public TeacherController(ITeacherService teacherService, IPositionService positionService)
        {
            _teacherService = teacherService;
            _positionService = positionService;
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
            var result = _teacherService.Add(teacher);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
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
        public IActionResult Edit(TeacherUpdateDto teacher)
        {
            var result = _teacherService.Update(teacher);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(teacher);
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
