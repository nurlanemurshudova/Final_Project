using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITeacherService _teacherService;


        public AboutController(IAboutService aboutService,ITeacherService teacherService)
        {
            _aboutService = aboutService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var teacherData = _teacherService.GetTeacherWithPositions().Data;
            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
                Teachers = teacherData,
            };
            return View(viewModel);
        }
    }
}
