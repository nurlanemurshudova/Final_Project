using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AppointmentCreateDto
    {
        public string GurdianName { get; set; }
        public string GurdianEmail { get; set; }
        public string ChildName { get; set; }
        public byte ChildAge { get; set; }
        public string Message { get; set; }
        public static Appointment ToAppointment(AppointmentCreateDto dto)
        {
            Appointment appointment = new()
            {
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
