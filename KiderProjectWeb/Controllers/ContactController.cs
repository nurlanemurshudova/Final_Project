using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto, out Dictionary<string, string> propertyNames);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var item in propertyNames)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                return View(dto);
            }
            TempData["SuccessMessage"] = "Məlumat uğurla göndərildi!";
            return RedirectToAction("Index");
        }
    }
}
