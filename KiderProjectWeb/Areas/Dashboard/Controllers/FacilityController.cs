using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FacilityController : Controller
    {
        FacilityManager _facilityManager = new();
        public IActionResult Index()
        {
            var data = _facilityManager.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Facility facility)
        {
            var result = _facilityManager.Add(facility);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(facility);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _facilityManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Facility facility)
        {
            var result = _facilityManager.Update(facility);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(facility);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _facilityManager.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }

    }
}
