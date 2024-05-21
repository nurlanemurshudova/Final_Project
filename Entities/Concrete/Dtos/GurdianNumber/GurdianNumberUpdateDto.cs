using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class GurdianNumberUpdateDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int AppontmentId { get; set; }
        public static GurdianNumber ToGurdianNumber(GurdianNumberUpdateDto dto)
        {
            GurdianNumber gurdianNumber = new()
            {
                Id = dto.Id,
                Number = dto.Number,
                AppontmentId = dto.AppontmentId,
            };
            return gurdianNumber;
        }
    }
}
