using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestimonialUpdateDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Feedback { get; set; }
        public string PhotoUrl { get; set; }
        public static Testimonial ToTestimonial(TestimonialUpdateDto dto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Feedback = dto.Feedback,
                PhotoUrl = dto.PhotoUrl,
            };
            return testimonial;
        }
    }
}
