using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SchoolClassTeacherCreateDto
    {
        public int TeacherId { get; set; }
        public int SchoolClassId { get; set; }
        public static SchoolClassTeacher ToClassTeacher(SchoolClassTeacherCreateDto dto)
        {
           SchoolClassTeacher classTeacher = new SchoolClassTeacher()
           {
               SchoolClassId = dto.SchoolClassId,
               TeacherId = dto.TeacherId,
           };
            return classTeacher;
        }
    }
}
