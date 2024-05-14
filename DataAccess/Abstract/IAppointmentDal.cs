using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IAppointmentDal : IBaseRepository<Appointment> { }

}
