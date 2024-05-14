using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ISchoolClassService
    {
        IResult Add(SchoolClass entity);
        IResult Update(SchoolClass entity);
        IResult Delete(int id);
        IDataResult<List<SchoolClass>> GetAll();
        IDataResult<SchoolClass> GetById(int id);
    }    


}
