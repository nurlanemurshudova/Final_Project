using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TeacherCandidateController : BaseController
    {
        private readonly ITeacherCandidateService _teacherCandidateService;
        private readonly IWebHostEnvironment _env;
        public TeacherCandidateController(ITeacherCandidateService teacherCandidateService, IWebHostEnvironment env)
        {
            _teacherCandidateService = teacherCandidateService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _teacherCandidateService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherCandidateCreateDto teacherCandidate, IFormFile photoUrl)
        {
            if (photoUrl != null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Şəkil boş ola bilməz");
                return View(teacherCandidate);
            }
            var result = _teacherCandidateService.Add(teacherCandidate, photoUrl, _env.WebRootPath, out Dictionary<string, string> propertyNames);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            AddModelError(propertyNames);
            return View(teacherCandidate);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _teacherCandidateService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeacherCandidateUpdateDto teacherCandidate, IFormFile photoUrl)
        {
            var result = _teacherCandidateService.Update(teacherCandidate, photoUrl, _env.WebRootPath, out Dictionary<string, string> propertyNames);

            if (!result.IsSuccess)
            {
                AddModelError(propertyNames);
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _teacherCandidateService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
