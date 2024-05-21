using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SchoolClassTeacherController : Controller
    {
        private readonly ISchoolClassTeacherService _schoolClassTeacherService;
        public SchoolClassTeacherController(ISchoolClassTeacherService schoolClassTeacherService)
        {
            _schoolClassTeacherService = schoolClassTeacherService;
        }

        public IActionResult Index()
        {
            var data = _schoolClassTeacherService.GetClassTeacherWithClass().Data;

            return View(data);       
        }


    }
}
