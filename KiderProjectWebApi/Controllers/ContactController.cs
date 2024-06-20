using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("GetContacts")]
        public IActionResult GetContacts()
        {
            var result = _contactService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        //[HttpGet("GetAppointment/{id}")]
        //public IActionResult GetAppointment(int id)
        //{
        //    var result = _appointmentService.GetById(id);

        //    if (result.IsSuccess)
        //        return Ok(result);

        //    return BadRequest("Görüş tapılmadı");
        //}

        [HttpPost("AddContact")]
        public IActionResult AddAppointment(ContactCreateDto dto)
        {
            var result = _contactService.Add(dto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateAppointment(ContactUpdateDto dto)
        {
            var result = _contactService.Update(dto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var result = _contactService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
