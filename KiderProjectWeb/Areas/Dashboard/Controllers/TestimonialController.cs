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
        public IActionResult Create(TestimonialCreateDto testimonial)
        {
            var result = _testimonialService.Add(testimonial, _env.WebRootPath);
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
                return View(testimonial);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TestimonialUpdateDto testimonial)
        {
            var result = _testimonialService.Update(testimonial,  _env.WebRootPath);
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
                return View(testimonial);
            }
            return RedirectToAction("Index");
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
