using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IResult Add(Teacher entity);
        IResult Update(Teacher entity);
        IResult Delete(int id);
        IDataResult<List<Teacher>> GetAll();
        IDataResult<Teacher> GetById(int id);
    }    

}
