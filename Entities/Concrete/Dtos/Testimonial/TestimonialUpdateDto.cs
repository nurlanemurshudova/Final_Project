using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class TestimonialUpdateDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Feedback { get; set; }
        public IFormFile PhotoUrl { get; set; }
        
    }
}
