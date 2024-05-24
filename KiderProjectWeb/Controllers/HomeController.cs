using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITestimonialService _testimonialService;

        public HomeController(IAboutService aboutService, ITestimonialService testimonialService)
        {
            _aboutService = aboutService;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
            };
            return View(viewModel);
        }

       
    }
}
