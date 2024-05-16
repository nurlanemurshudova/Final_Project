using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new About()
            {
                Id = dto.Id,
                Description = dto.Description
            };
            return about;
        }
    }
}
