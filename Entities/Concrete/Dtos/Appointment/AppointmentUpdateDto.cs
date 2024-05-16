using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos 
{ 
    public class AppointmentUpdateDto
    {
    public int Id { get; set; }
    public string GurdianName { get; set; }
    public string GurdianEmail { get; set; }
    public string ChildName { get; set; }
    public byte ChildAge { get; set; }
    public string Message { get; set; }
    public static Appointment ToAppointment(AppointmentUpdateDto dto)
    {
        Appointment appointment = new()
        {
            Id = dto.Id,
            GurdianName = dto.GurdianName,
            GurdianEmail = dto.GurdianEmail,
            ChildName = dto.ChildName,
            ChildAge = dto.ChildAge,
            Message = dto.Message
        };
        return appointment;
    }
}
}
