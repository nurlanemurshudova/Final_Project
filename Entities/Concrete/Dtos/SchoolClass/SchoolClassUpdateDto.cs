using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class SchoolClassUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChildAge { get; set; }
        public bool IsHomePage { get; set; }
        public string Time { get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public List<int> TeacherIds { get; set; }

    }
}
