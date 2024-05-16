namespace Entities.Concrete.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string GurdianName { get; set; }
        public string GurdianEmail { get; set; }
        public string ChildName { get; set; }
        public byte ChildAge { get; set; }
        public string Message { get; set; }
    }
}
