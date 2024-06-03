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
            if (photoUrl != null)
            {
                var result = _teacherCandidateService.Add(teacherCandidate, photoUrl, _env.WebRootPath);
                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Məlumat uğurla göndərildi!";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }

            return View(teacherCandidate);
        }
    }
}
