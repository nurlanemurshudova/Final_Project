using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassService;
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _env;
        public SchoolClassController(ISchoolClassService schoolClassService, ITeacherService teacherService, IWebHostEnvironment env)
        {
            _schoolClassService = schoolClassService;
            _teacherService = teacherService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _schoolClassService.GetAll().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Teachers"] = _teacherService.GetTeacherWithPositions().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(SchoolClassCreateDto schoolClass, IFormFile photoUrl)
        {
            var result = _schoolClassService.Add(schoolClass, photoUrl, _env.WebRootPath);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(schoolClass);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Teachers"] = _teacherService.GetTeacherWithPositions().Data;

            var data = _schoolClassService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SchoolClassUpdateDto dto, IFormFile photoUrl)
        {
            var result = _schoolClassService.Update(dto, photoUrl, _env.WebRootPath);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _schoolClassService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

    }
}
