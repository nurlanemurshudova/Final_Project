using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiderProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCandidateController : ControllerBase
    {
        private readonly ITeacherCandidateService _teacherCandidateservice;

        public TeacherCandidateController(ITeacherCandidateService teacherCandidateservice)
        {
            _teacherCandidateservice = teacherCandidateservice;
        }
        [HttpGet("GetTeacherCandidates")]
        public IActionResult GetTeacherCandidates()
        {
            var result = _teacherCandidateservice.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("AddTeacherCandidate")]
        public IActionResult AddTeacherCandidate([FromForm] TeacherCandidateCreateDto dto)
        {

            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _teacherCandidateservice.Add(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Göndərilən məlumat doğru deyil");
        }

        [HttpPut("UpdateTeacherCandidate")]
        public IActionResult UpdateTeacherCandidate([FromForm] TeacherCandidateUpdateDto dto)
        {
            string wwwrootFolder = Path.Combine("..", "KiderProjectWeb", "wwwroot");
            var result = _teacherCandidateservice.Update(dto, wwwrootFolder);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat yenilənə bilmədi");
        }

        [HttpDelete("DeleteTeacherCandidate/{id}")]
        public IActionResult DeleteTeacherCandidate(int id)
        {
            var result = _teacherCandidateservice.Delete(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest("Məlumat silinə bilmədi");
        }
    }
}
