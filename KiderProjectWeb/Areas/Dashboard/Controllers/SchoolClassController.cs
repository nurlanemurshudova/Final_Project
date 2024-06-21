using Business.Abstract;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassService;
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _env;
        public SchoolClassController(ISchoolClassService schoolClassService, IWebHostEnvironment env, ITeacherService teacherService)
        {
            _schoolClassService = schoolClassService;
            _teacherService = teacherService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _schoolClassService.GetAllClassWithDetails().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Teachers"] = _teacherService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(SchoolClassCreateDto schoolClass, IFormFile photoUrl)
        {
            if (photoUrl != null)
            {
                var result = _schoolClassService.Add(schoolClass, photoUrl, _env.WebRootPath);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                var errorResult = result as ErrorResult;
                if (errorResult != null)
                {
                    ModelState.Clear();
                    foreach (var error in errorResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            ModelState.AddModelError("", "Sekil elave et");
            ViewData["Teachers"] = _teacherService.GetAll().Data;
            return View(schoolClass);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var data = _schoolClassService.GetById(id).Data;

            //ViewData["Teachers"] = _teacherService.GetAll().Data;
            //return View(data);
            var classResult = _schoolClassService.GetByIdClassWithDetails(id).Data;
            var selectedClassTeacherIds = new List<int>();
            if (classResult.SchoolClassTeachers != null)
            {
                selectedClassTeacherIds = classResult.SchoolClassTeachers.Select(sct => sct.TeacherId).ToList();
            }
            ViewData["Teachers"] = _teacherService.GetAll().Data;
            ViewData["SelectedClassTeacherIds"] = selectedClassTeacherIds;

            return View(classResult);
        }

            


        [HttpPost]
        public IActionResult Edit(SchoolClassUpdateDto dto, IFormFile photoUrl)
        {
            var result = _schoolClassService.Update(dto, photoUrl, _env.WebRootPath);
            
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
                return View(dto);
            }

            ViewData["Teachers"] = _teacherService.GetAll().Data;
            return RedirectToAction("Index");

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
