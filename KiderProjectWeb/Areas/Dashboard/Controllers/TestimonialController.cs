using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _env;
        public TestimonialController(ITestimonialService testimonialService, IWebHostEnvironment env)
        {
            _testimonialService = testimonialService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Create(TestimonialCreateDto testimonial, IFormFile photoUrl)
        public IActionResult Create(TestimonialCreateDto testimonial)
        {
            //var result = _testimonialService.Add(testimonial, photoUrl, _env.WebRootPath);
            var result = _testimonialService.Add(testimonial);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(testimonial);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        //public IActionResult Edit(TestimonialUpdateDto testimonial, IFormFile photoUrl)
        public IActionResult Edit(TestimonialUpdateDto testimonial)
        {
            var result = _testimonialService.Update(testimonial);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(testimonial);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _testimonialService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
