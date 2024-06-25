using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class SlideCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
