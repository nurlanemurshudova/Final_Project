using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
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
        private readonly ISchoolClassService _schoolClassService;
        private readonly ITeacherService _teacherService;
        private readonly ISchoolClassTeacherService _classTeacherService;

        public HomeController(IAboutService aboutService,
            ITestimonialService testimonialService,
            IFacilityService facilityService,
            ISlideService slideService,
            ISchoolClassService schoolClassService,
            ITeacherService teacherService,
            ISchoolClassTeacherService classTeacherService,
            IAppointmentService appointmentService)
        {
            _aboutService = aboutService;
            _testimonialService = testimonialService;
            _facilityService = facilityService;
            _slideService = slideService;
            _schoolClassService = schoolClassService;
            _teacherService = teacherService;
            _classTeacherService = classTeacherService;
        }
        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var facilityData = _facilityService.GetAll().Data;
            var slideData = _slideService.GetAll().Data;
            var classData = _schoolClassService.GetAllClassWithDetails().Data;
            var teacherData = _teacherService.GetTeacherWithPositions().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            var classTeacherData = _classTeacherService.GetAllClassTeacherWithClass().Data;
            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
                Facilities = facilityData,
                Slides = slideData,
                SchoolClasses = classData,
                Teachers = teacherData,
                Testimonials = testimonialData,
                ClassTeachers = classTeacherData,
            };
            return View(viewModel);
        }

    }
}
