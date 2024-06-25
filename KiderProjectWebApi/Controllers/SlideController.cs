using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }
        [HttpGet("GetSlides")]
        public IActionResult GetSlides()
        {
            var result = _slideService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddSlide")]
        public IActionResult AddSlide([FromForm] SlideCreateDto dto)
        {

            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _slideService.Add(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateSlide")]
        public IActionResult UpdateSlide([FromForm] SlideUpdateDto dto)
        {
            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _slideService.Update(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteSlide/{id}")]
        public IActionResult DeleteSlide(int id)
        {
            var result = _slideService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
