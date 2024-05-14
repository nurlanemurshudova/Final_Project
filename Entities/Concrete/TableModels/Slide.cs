using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Slide : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}
