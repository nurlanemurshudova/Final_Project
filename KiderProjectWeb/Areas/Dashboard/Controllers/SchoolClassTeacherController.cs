using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
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
        public IActionResult Edit(int id)
        {
            ViewData["Teachers"] = _teacherService.GetAll().Data;
            var data = _schoolClassTeacherService.GetByIdClassTeacherWithClass(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SchoolClassTeacherUpdateDto classTeacher)
        {
            var result = _schoolClassTeacherService.Update(classTeacher);


            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(classTeacher);
            }
            ViewData["Teachers"] = _teacherService.GetAll().Data;
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
