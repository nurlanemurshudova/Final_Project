using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFacilityService
    {
        IResult Add(FacilityCreateDto entity);
        IResult Update(FacilityUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Facility>> GetAll();
        IDataResult<Facility> GetById(int id);
    }


}
