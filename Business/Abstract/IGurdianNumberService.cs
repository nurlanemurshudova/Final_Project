using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IGurdianNumberService
    {
        IResult Add(GurdianNumber entity);
        IResult Update(GurdianNumber entity);
        IResult Delete(int id);
        IDataResult<List<GurdianNumber>> GetNumberWithAppointments();
        IDataResult<GurdianNumber> GetById(int id);
    }


}
