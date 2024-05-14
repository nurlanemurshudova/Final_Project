using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Position : BaseEntity
    {
        public Position()
        {
            Teachers = new HashSet<Teacher>();
        }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
