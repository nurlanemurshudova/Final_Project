using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class TeacherCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int PositionId { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public byte Experience { get; set; }
    }
}
