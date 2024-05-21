using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ISlideService
    {
        IResult Add(SlideCreateDto entity, IFormFile photoUrl, string webRootPath);
        IResult Update(SlideUpdateDto entity, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Slide>> GetAll();
        IDataResult<Slide> GetById(int id);
    }    


}
