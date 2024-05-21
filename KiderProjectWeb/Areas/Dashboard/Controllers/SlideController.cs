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
        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
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
            var result = _slideService.Add(slide);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(slide);
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
            var result = _slideService.Update(slide);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(slide);
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
