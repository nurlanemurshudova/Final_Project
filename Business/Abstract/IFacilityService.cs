using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFacilityService
    {
        IResult Add(FacilityCreateDto entity, out Dictionary<string, string> propertyNames);
        IResult Update(FacilityUpdateDto entity, out Dictionary<string, string> propertyNames);
        IResult Delete(int id);
        IDataResult<List<Facility>> GetAll();
        IDataResult<Facility> GetById(int id);
    }


}
