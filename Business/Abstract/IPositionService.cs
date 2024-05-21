using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IResult Add(PositionCreateDto entity);
        IResult Update(PositionUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Position>> GetAll();
        IDataResult<Position> GetById(int id);
    }    


}
