using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FacilityController : Controller
    {
        private readonly IFacilityService _facilityService;
        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        public IActionResult Index()
        {
            var data = _facilityService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FacilityCreateDto facility)
        {
            var result = _facilityService.Add(facility);
            if (result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return RedirectToAction("Index");
            }

            return View(facility);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _facilityService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FacilityUpdateDto facility)
        {
            var result = _facilityService.Update(facility);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(facility);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _facilityService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }

    }
}
