using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var testimonialData = _testimonialService.GetAll().Data;
            TestimonialViewModel viewModel = new()
            {
                Testimonials = testimonialData,
            };
            return View(viewModel);
        }
    }
}
