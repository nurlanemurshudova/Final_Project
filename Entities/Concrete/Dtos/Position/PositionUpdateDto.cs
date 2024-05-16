using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class PositionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static Position ToPosition(PositionUpdateDto dto)
        {
            Position position = new Position()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return position;
        }
    }
}
