using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GurdianNumberController : Controller
    {
        GurdianNumberManager _gurdianNumberManager = new();
        AppointmentManager appointmentManager = new();
        public IActionResult Index()
        {
            var data = _gurdianNumberManager.GetNumberWithAppointments().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Appointments"] = appointmentManager.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(GurdianNumber gurdianNumber)
        {
            var result = _gurdianNumberManager.Add(gurdianNumber);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gurdianNumber);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["FoodCategories"] = appointmentManager.GetAll().Data;

            var data = _gurdianNumberManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(GurdianNumber gurdianNumber)
        {
            var result = _gurdianNumberManager.Update(gurdianNumber);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(gurdianNumber);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _gurdianNumberManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

    }
}
