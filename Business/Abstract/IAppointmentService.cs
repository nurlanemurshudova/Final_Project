using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        IResult Add(Appointment entity);
        IResult Update(Appointment entity);
        IResult Delete(int id);
        IDataResult<List<Appointment>> GetAll();
        IDataResult<Appointment> GetById(int id);
    }
}
