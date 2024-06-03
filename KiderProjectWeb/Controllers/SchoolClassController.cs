using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassService;
        private readonly ITeacherService _teacherService;
        private readonly ISchoolClassTeacherService _classTeacherService;
        private readonly ITestimonialService _testimonialService;

        public SchoolClassController(ISchoolClassService schoolClassService,
            ITeacherService teacherService,
            ISchoolClassTeacherService classTeacherService,
            ITestimonialService testimonialService)
        {
            _schoolClassService = schoolClassService;
            _teacherService = teacherService;
            _classTeacherService = classTeacherService;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var classData = _schoolClassService.GetAllClassWithDetails().Data;
            var teacherData = _teacherService.GetTeacherWithPositions().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            var classTeacherData = _classTeacherService.GetAllClassTeacherWithClass().Data;
            ClassViewModel viewModel = new()
            {
                SchoolClasses = classData,
                Teachers = teacherData,
                Testimonials = testimonialData,
                ClassTeachers = classTeacherData,
            };
            return View(viewModel);
        }
    }
}
