using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ISchoolClassService
    {
        IResult Add(SchoolClassCreateDto entity);
        IResult Update(SchoolClassUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<SchoolClass>> GetAll();
        IDataResult<SchoolClass> GetById(int id);
    }    


}
