namespace Entities.Concrete.Dtos
{
    public class SchoolClassTeacherDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }

    }
}
