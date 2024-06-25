using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet("GetTestimonials")]
        public IActionResult GetTestimonials()
        {
            var result = _testimonialService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddTestimonial")]
        public IActionResult AddTestimonial([FromForm] TestimonialCreateDto dto)
        {

            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _testimonialService.Add(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateTestimonial")]
        public IActionResult UpdateTestimonial([FromForm] TestimonialUpdateDto dto)
        {
            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _testimonialService.Update(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteSlide/{id}")]
        public IActionResult DeleteSlide(int id)
        {
            var result = _testimonialService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
