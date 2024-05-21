using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class GurdianNumberCreateDto
    {
        public string Number { get; set; }
        public int AppontmentId { get; set; }
        public static GurdianNumber ToGurdianNumber(GurdianNumberCreateDto dto)
        {

            GurdianNumber gurdianNumber = new GurdianNumber
            {
                Number = dto.Number,
                AppontmentId = dto.AppontmentId,
            };

            return gurdianNumber;
        }
    }
}

