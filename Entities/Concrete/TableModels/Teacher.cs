using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public byte Experience { get; set; }
        //public List<SchoolClass> SchoolClasses { get; } = [];
        public List<SchoolClassTeacher> SchoolClassTeachers { get; } = [];
    }
}
