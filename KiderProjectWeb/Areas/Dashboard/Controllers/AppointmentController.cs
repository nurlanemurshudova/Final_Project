using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService; 
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var data = _appointmentService.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppointmentCreateDto appointment)
        {
            var result = _appointmentService.Add(appointment);
            if (result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _appointmentService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AppointmentUpdateDto appointment)
        {
            var result = _appointmentService.Update(appointment);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _appointmentService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
