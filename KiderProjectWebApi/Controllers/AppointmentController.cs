using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAppointments")]
        public IActionResult GetAppointments()
        {
            var result = _appointmentService.GetAll();

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

        [HttpPost("AddAppointment")]
        public IActionResult AddAppointment(AppointmentCreateDto dto)
        {
            var result = _appointmentService.Add(dto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateAppointment")]
        public IActionResult UpdateAppointment(AppointmentUpdateDto dto)
        {

            var result = _appointmentService.Update(dto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteAppointment/{id}")]
        public IActionResult DeleteAppointment(int id)
        {

            var result = _appointmentService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
