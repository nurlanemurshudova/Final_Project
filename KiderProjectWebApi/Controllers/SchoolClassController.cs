using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly ISchoolClassService _schoolClassService;
        private readonly IWebHostEnvironment _env;
        public SchoolClassController(ISchoolClassService schoolClassService, IWebHostEnvironment env)
        {
            _schoolClassService = schoolClassService;
            _env = env;
        }
        [HttpGet("GetClasses")]
        public IActionResult GetClasses()
        {
            var result = _schoolClassService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddClass")]
        public IActionResult AddClass(SchoolClassCreateDto dto, IFormFile photoUrl)
        {
            var result = _schoolClassService.Add(dto, photoUrl, _env.WebRootPath);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateClass")]
        public IActionResult UpdateClass(SchoolClassUpdateDto dto,IFormFile photoUrl)
        {
            var result = _schoolClassService.Update(dto, photoUrl, _env.WebRootPath);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteClass/{id}")]
        public IActionResult DeleteClass(int id)
        {
            var result = _schoolClassService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
