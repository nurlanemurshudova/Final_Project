using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeacherCandidateController : Controller
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
        public IActionResult Create(TeacherCandidateCreateDto teacherCandidate,IFormFile photoUrl)
        {
            var result = _teacherCandidateService.Add(teacherCandidate,photoUrl,_env.WebRootPath);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(teacherCandidate);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _teacherCandidateService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeacherCandidateUpdateDto teacherCandidate,IFormFile photoUrl)
        {
            var result = _teacherCandidateService.Update(teacherCandidate, photoUrl, _env.WebRootPath);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(teacherCandidate);
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
