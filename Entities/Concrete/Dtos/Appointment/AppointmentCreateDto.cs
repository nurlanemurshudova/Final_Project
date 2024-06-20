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
        public string FirstPhoneNumber { get; set; }
        public string SecondPhoneNumber { get; set; }
        public static Appointment ToAppointment(AppointmentCreateDto dto)
        {
            Appointment appointment = new()
            {
                GurdianName = dto.GurdianName,
                GurdianEmail = dto.GurdianEmail,
                ChildName = dto.ChildName,
                ChildAge = dto.ChildAge,
                Message = dto.Message,
                FirstPhoneNumber = dto.FirstPhoneNumber,
                SecondPhoneNumber = dto.SecondPhoneNumber,
                //GurdianNumbers = new List<GurdianNumber>
                //{
                //    new GurdianNumber{Number = dto.GurdianNumber1},
                //    new GurdianNumber{Number = dto.GurdianNumber2}
                //}
            };
            return appointment;
        }
    }
}
