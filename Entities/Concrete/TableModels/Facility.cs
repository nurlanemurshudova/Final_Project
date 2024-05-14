using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Facility :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
    }
}
