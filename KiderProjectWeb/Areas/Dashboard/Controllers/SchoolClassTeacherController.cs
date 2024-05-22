using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SchoolClassTeacherController : Controller
    {
        private readonly ISchoolClassTeacherService _schoolClassTeacherService;
        private readonly ITeacherService _teacherService;
        private readonly ISchoolClassService _classService;
        public SchoolClassTeacherController(ISchoolClassTeacherService schoolClassTeacherService, ITeacherService teacherService, ISchoolClassService classService)
        {
            _schoolClassTeacherService = schoolClassTeacherService;
            _teacherService = teacherService;
            _classService = classService;
        }

        public IActionResult Index()
        {
            var data = _schoolClassTeacherService.GetAllClassTeacherWithClass().Data;

            return View(data);       
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Teachers"] = _teacherService.GetAll().Data;
            ViewData["Classes"] = _classService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(SchoolClassTeacherCreateDto classTeacher)
        {
            var result = _schoolClassTeacherService.Add(classTeacher);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            return View(classTeacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Teachers"] = _teacherService.GetAllTeacherWithDetails().Data;
            ViewData["Classes"] = _classService.GetAll().Data;
            var data = _schoolClassTeacherService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SchoolClassTeacherUpdateDto schoolClass)
        {
            var result = _schoolClassTeacherService.Update(schoolClass);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(schoolClass);
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
