using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly ISchoolClassService _schoolClassService;
        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
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
        public IActionResult AddClass([FromForm] SchoolClassCreateDto dto)
        {

            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _schoolClassService.Add(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateClass")]
        public IActionResult UpdateClass([FromForm]SchoolClassUpdateDto dto)
        {
            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _schoolClassService.Update(dto, wwwrootFolder);

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
