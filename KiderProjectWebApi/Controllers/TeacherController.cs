using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("GetTeachers")]
        public IActionResult GetTeachers()
        {
            var result = _teacherService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddTeacher")]
        public IActionResult AddTeacher([FromForm] TeacherCreateDto dto)
        {

            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _teacherService.Add(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateTeacher")]
        public IActionResult UpdateTeacher([FromForm] TeacherUpdateDto dto)
        {
            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _teacherService.Update(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteTeacher/{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var result = _teacherService.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
