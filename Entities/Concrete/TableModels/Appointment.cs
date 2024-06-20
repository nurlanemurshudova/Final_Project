using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Appointment : BaseEntity
    {
        //public Appointment() 
        //{
        //    GurdianNumbers = new HashSet<GurdianNumber>();
        //}
        public string GurdianName { get; set; }
        public string GurdianEmail { get; set; }
        public string ChildName { get; set; }
        public byte ChildAge { get; set; }
        public string Message { get; set; }
        public string FirstPhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        //public ICollection<GurdianNumber> GurdianNumbers { get; set;}

    }
}
