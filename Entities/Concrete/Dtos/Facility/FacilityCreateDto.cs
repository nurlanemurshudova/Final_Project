using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FacilityCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public static Facility ToFacility(FacilityCreateDto dto)
        {
            Facility facility = new Facility()
            {
                Name = dto.Name,
                Description = dto.Description,
                IconName = dto.IconName,
            };
            return facility;
        }
    }
}
