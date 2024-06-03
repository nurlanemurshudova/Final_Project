using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AppointmentCreateDto appointment)
        {
            var result = _appointmentService.Add(appointment, out Dictionary<string, string> propertyNames);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var item in propertyNames)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                return View();
            }
            TempData["SuccessMessage"] = "Məlumat uğurla göndərildi!";
            return RedirectToAction("Index");


        }
    }
}
