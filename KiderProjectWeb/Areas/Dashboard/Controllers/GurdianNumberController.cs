using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GurdianNumberController : BaseController
    {
        private readonly IGurdianNumberService _gurdianNumberService;
        private readonly IAppointmentService _appointmentService;
        public GurdianNumberController(IGurdianNumberService gurdianNumberService, IAppointmentService appointmentService)
        {
            _gurdianNumberService = gurdianNumberService;
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var data = _gurdianNumberService.GetNumberWithAppointments().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Appointments"] = _appointmentService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(GurdianNumberCreateDto gurdianNumber)
        {
            var result = _gurdianNumberService.Add(gurdianNumber, out Dictionary<string, string> properties);
            if (!result.IsSuccess)
            {
                ViewData["Appointments"] = _appointmentService.GetAll().Data;
                AddModelError(properties);
                return View(gurdianNumber);
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Appointments"] = _appointmentService.GetAll().Data;

            var data = _gurdianNumberService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(GurdianNumberUpdateDto gurdianNumber)
        {
            var result = _gurdianNumberService.Update(gurdianNumber, out Dictionary<string, string> properties);
            if (!result.IsSuccess)
            {
                ViewData["Appointments"] = _appointmentService.GetAll().Data;
                AddModelError(properties);
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _gurdianNumberService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

    }
}
