using Business.Abstract;
using Core.Results.Concrete;
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
        public IActionResult Index(TeacherCandidateCreateDto teacherCandidate)
        {
            var result = _teacherCandidateService.Add(teacherCandidate, _env.WebRootPath);
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
                return View(teacherCandidate);
            }
            TempData["SuccessMessage"] = "Məlumat uğurla göndərildi!";
            return RedirectToAction("Index");
        }
    }
}
