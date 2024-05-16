using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int PositionId { get; set; }
        public string[] PositionName { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public byte Experience { get; set; }
        public static Teacher ToTeacher(TeacherUpdateDto dto)
        {
            Teacher teacher = new Teacher()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                InstagramUrl = dto.InstagramUrl,
                FacebookUrl = dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl,
                PositionId = dto.PositionId,
                PhotoUrl = dto.PhotoUrl,
                IsHomePage = dto.IsHomePage,
                Experience = dto.Experience,
            };
            foreach (var positionName in dto.PositionName)
            {
                Position position = new()
                {
                    Name = positionName,
                };
            }
            return teacher;
        }
    }
}
