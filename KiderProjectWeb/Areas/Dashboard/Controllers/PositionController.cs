using Business.Abstract;
using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var data = _positionService.GetAll().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PositionCreateDto position)
        {
            var result = _positionService.Add(position);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("Name", result.Message);
                return View(position);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _positionService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PositionUpdateDto position)
        {
            var result = _positionService.Update(position);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("Name", result.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _positionService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
