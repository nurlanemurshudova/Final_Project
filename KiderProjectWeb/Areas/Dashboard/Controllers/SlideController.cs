using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
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
        public IActionResult Create(SlideCreateDto slide, IFormFile photoUrl)
        {
            if (photoUrl != null)
            {
                var result = _slideService.Add(slide, photoUrl, _env.WebRootPath);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(slide);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _slideService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SlideUpdateDto slide, IFormFile photoUrl)
        {
            var result = _slideService.Update(slide, photoUrl, _env.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View();
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
