using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SlideUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public static Slide ToSlide(SlideUpdateDto dto)
        {
            Slide slide = new Slide()
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return slide;
        }
    }
}
