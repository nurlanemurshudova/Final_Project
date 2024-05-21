using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IGurdianNumberService
    {
        IResult Add(GurdianNumberCreateDto entity);
        IResult Update(GurdianNumberUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<GurdianNumberDto>> GetNumberWithAppointments();
        IDataResult<GurdianNumber> GetById(int id);
    }


}
