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
    public class FacilityController : BaseController
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
            var result = _facilityService.Add(facility, out Dictionary<string, string> properties);
            if (!result.IsSuccess)
            {
                AddModelError(properties);
                return View(facility);
            }
            return RedirectToAction("Index");
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
            var result = _facilityService.Update(facility, out Dictionary<string, string> properties);

            if (!result.IsSuccess)
            {
                AddModelError(properties);
                return View();
            }
            return RedirectToAction("Index");
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
