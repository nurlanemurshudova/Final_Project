using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class SchoolClass : BaseEntity
    {
        public string Name { get; set; }
        public string ChildAge { get; set; }
        public bool IsHomePage { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SchoolClassTeacher> SchoolClassTeachers { get; set; }
        public string Time {  get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }

    }
}
