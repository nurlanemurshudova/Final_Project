using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SlideCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public static Slide ToSlide(SlideCreateDto dto)
        {
            Slide slide = new Slide()
            {
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return slide;
        }
    }
}
