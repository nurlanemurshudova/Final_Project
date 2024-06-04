using Business.Abstract;
using KiderProjectWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public IActionResult Index()
        {
            var teacherData = _teacherService.GetTeacherWithPositions().Data;
            TeacherViewModel viewModel = new()
            {
                Teachers = teacherData,
            };
            return View(viewModel);
        }
    }
}
