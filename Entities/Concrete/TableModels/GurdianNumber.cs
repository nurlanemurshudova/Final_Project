using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class GurdianNumber : BaseEntity
    {   
        public string Number { get; set; }
        public int AppontmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
