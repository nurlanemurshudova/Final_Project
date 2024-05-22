using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SchoolClassTeacherUpdateDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SchoolClassId { get; set; }
        public static SchoolClassTeacher ToClassTeacher(SchoolClassTeacherUpdateDto dto)
        {
            SchoolClassTeacher classTeacher = new SchoolClassTeacher()
            {
                Id = dto.Id,
                SchoolClassId = dto.SchoolClassId,
                TeacherId = dto.TeacherId,
            };
            return classTeacher;
        }
    }
}
