using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AppointmentController : Controller
    {
        AppointmentManager _appointmentManager = new();
        public IActionResult Index()
        {
            var data = _appointmentManager.GetAll().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            var result = _appointmentManager.Add(appointment);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _appointmentManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            var result = _appointmentManager.Update(appointment);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _appointmentManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
