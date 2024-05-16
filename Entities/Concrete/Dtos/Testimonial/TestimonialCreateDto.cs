using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestimonialCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Feedback { get; set; }
        public string PhotoUrl { get; set; }
        public static Testimonial ToTestimonial(TestimonialCreateDto dto)
        {
            Testimonial testimonial = new Testimonial()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Feedback = dto.Feedback,
                PhotoUrl = dto.PhotoUrl,
            };
            return testimonial;
        }
    }
}
