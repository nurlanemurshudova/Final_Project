using Business.Abstract;
using Business.Concrete;
using Core.Results.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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
        public IActionResult Create(TeacherCandidateCreateDto teacherCandidate)
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _teacherCandidateService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TeacherCandidateUpdateDto teacherCandidate)
        {
            var result = _teacherCandidateService.Update(teacherCandidate, _env.WebRootPath);
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
