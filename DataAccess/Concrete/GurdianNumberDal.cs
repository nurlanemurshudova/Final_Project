using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class GurdianNumberDal : BaseRepository<GurdianNumber, ApplicationDbContext>, IGurdianNumberDal
    {
        ApplicationDbContext context = new();
        public List<GurdianNumber> GetNumberWithAppointments()
        {
            var data = context.GurdianNumbers
                .Where(x => x.Deleted == 0)
                .Include(x => x.Appointment).ToList();
            return data;
        }
    }
}
