using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ISlideService
    {
        IResult Add(SlideCreateDto entity);
        IResult Update(SlideUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Slide>> GetAll();
        IDataResult<Slide> GetById(int id);
    }    


}
