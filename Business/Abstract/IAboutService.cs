using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About entity);
        IResult Update(About entity);
        IResult Delete(int id);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetById(int id);
    }
}
