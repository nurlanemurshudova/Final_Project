using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IGurdianNumberService
    {
        IResult Add(GurdianNumberCreateDto entity,out Dictionary<string, string> propertyNames);
        IResult Update(GurdianNumberUpdateDto entity, out Dictionary<string, string> propertyNames);
        IResult Delete(int id);
        IDataResult<List<GurdianNumberDto>> GetNumberWithAppointments();
        IDataResult<GurdianNumber> GetById(int id);
    }


}
