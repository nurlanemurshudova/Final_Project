using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AppointmentController : BaseController
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
            var result = _appointmentService.Add(appointment, out Dictionary<string, string> propertyNames);
            if (!result.IsSuccess)
            {
                //ModelState.Clear();
                //ModelState.AddModelError("",result.Message);
                AddModelError(propertyNames);
                return View();
            }

            return RedirectToAction("Index");


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
            var result = _appointmentService.Update(appointment, out Dictionary<string, string> propertyNames);

            if (!result.IsSuccess)
            {
                //ModelState.Clear();
                //ModelState.AddModelError("", result.Message);
                AddModelError(propertyNames);
                return View();
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _appointmentService.Delete(id);
            if (!result.IsSuccess)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
