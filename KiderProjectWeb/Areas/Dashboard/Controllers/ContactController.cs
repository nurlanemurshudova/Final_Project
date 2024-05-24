using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactCreateDto contact)
        {
            var result = _contactService.Add(contact, out Dictionary<string, string> propertyNames);
            if (!result.IsSuccess)
            {
                //ModelState.Clear();
                //ModelState.AddModelError("", result.Message);
                AddModelError(propertyNames);
                return View(contact);
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _contactService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ContactUpdateDto contact)
        {
            var result = _contactService.Update(contact, out Dictionary<string, string> propertyNames);

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
            var result = _contactService.Delete(id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
