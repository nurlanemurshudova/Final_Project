using Business.Abstract;
using Business.Concrete;
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
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IWebHostEnvironment _env;
        public SlideController(ISlideService slideService, IWebHostEnvironment env)
        {
            _slideService = slideService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _slideService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SlideCreateDto slide)
        {
            var result = _slideService.Add(slide, _env.WebRootPath);
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
                return View(slide);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _slideService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SlideUpdateDto slide)
        {
            var result = _slideService.Update(slide, _env.WebRootPath);

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
                return View(slide);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _slideService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
