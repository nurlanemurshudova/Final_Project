using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FacilityUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public static Facility ToFacility(FacilityUpdateDto dto)
        {
            Facility facility = new Facility()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IconName = dto.IconName,
            };
            return facility;
        }
    }
}
