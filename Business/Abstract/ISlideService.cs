using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ISlideService
    {
        IResult Add(Slide entity);
        IResult Update(Slide entity);
        IResult Delete(int id);
        IDataResult<List<Slide>> GetAll();
        IDataResult<Slide> GetById(int id);
    }    


}
