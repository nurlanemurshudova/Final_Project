using Business.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new();

        public IActionResult Index()
        {
            var data = _aboutManager.GetAll().Data;

            ViewBag.ShowButton = data.Count() == 0;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AboutCreateDto dto)
        {
            var result = _aboutManager.Add(dto);
            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AboutUpdateDto dto)
        {
            var result = _aboutManager.Update(dto);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);
        }
    }
}
