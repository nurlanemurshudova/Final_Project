using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITestimonialService _testimonialService;
        private readonly IFacilityService _facilityService;
        private readonly ISlideService _slideService;

        public HomeController(IAboutService aboutService, ITestimonialService testimonialService, IFacilityService facilityService, ISlideService slideService)
        {
            _aboutService = aboutService;
            _testimonialService = testimonialService;
            _facilityService = facilityService;
            _slideService = slideService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var facilityData = _facilityService.GetAll().Data;
            var slideData = _slideService.GetAll().Data;
            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
                Facilities = facilityData,
                Slides = slideData,
            };
            return View(viewModel);
        }

       
    }
}
