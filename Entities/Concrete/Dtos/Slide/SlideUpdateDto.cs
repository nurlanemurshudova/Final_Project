using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class SlideUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
