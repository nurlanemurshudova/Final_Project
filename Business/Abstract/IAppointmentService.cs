using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        IResult Add(AppointmentCreateDto entity);
        IResult Update(AppointmentUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Appointment>> GetAll();
        IDataResult<Appointment> GetById(int id);
    }
}
