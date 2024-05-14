using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFacilityService
    {
        IResult Add(Facility entity);
        IResult Update(Facility entity);
        IResult Delete(int id);
        IDataResult<List<Facility>> GetAll();
        IDataResult<Facility> GetById(int id);
    }


}
