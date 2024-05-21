using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class GurdianNumberDal : BaseRepository<GurdianNumber, ApplicationDbContext>, IGurdianNumberDal
    {
        private readonly ApplicationDbContext _context;

        public GurdianNumberDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<GurdianNumberDto> GetNumberWithAppointments()
        {
            var result = from number in _context.GurdianNumbers
                         where number.Deleted == 0
                         join appointment in _context.Appointments
                         on number.AppontmentId equals appointment.Id
                         where appointment.Deleted == 0
                         select new GurdianNumberDto
                         {
                             Id = number.Id,
                             Number = number.Number,
                             AppontmentId = appointment.Id,
                             AppontmentName= appointment.GurdianName
                         };

            return result.ToList();
        }
    }
}
