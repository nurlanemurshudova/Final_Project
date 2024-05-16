using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class SchoolClassTeacher : BaseEntity
    {
        public int TeacherId { get; set; }
        public int SchoolClassId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public SchoolClass SchoolClass { get; set; } = null!;
    }
}
