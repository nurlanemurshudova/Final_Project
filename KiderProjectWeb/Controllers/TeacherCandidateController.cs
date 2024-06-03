using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class TeacherCandidateController : Controller
    {
        private readonly ITeacherCandidateService _teacherCandidateService;
        private readonly IWebHostEnvironment _env;
        public TeacherCandidateController(ITeacherCandidateService teacherCandidateService, IWebHostEnvironment env)
        {
            _teacherCandidateService = teacherCandidateService;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TeacherCandidateCreateDto teacherCandidate, IFormFile photoUrl)
        {
            if (photoUrl == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Fotoğraf yüklemesi gereklidir.");
                return View(teacherCandidate);
            }

            var result = _teacherCandidateService.Add(teacherCandidate, photoUrl, _env.WebRootPath, out Dictionary<string, string> propertyNames);
            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = "Məlumat uğurla göndərildi!";
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            foreach (var item in propertyNames)
            {
                ModelState.AddModelError(item.Key, item.Value);
            }

            return View(teacherCandidate);
        }
    }
}
