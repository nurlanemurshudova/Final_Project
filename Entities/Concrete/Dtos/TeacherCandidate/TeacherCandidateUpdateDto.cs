using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;
namespace Entities.Concrete.Dtos
{
    public class TeacherCandidateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public bool IsContacted { get; set; }
    }
}
