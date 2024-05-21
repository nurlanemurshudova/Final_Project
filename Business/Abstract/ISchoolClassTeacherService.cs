using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ISchoolClassTeacherService
    {
        IResult Add(SchoolClassTeacher entity);
        IResult Update(SchoolClassTeacher entity);
        IResult Delete(int id);
        IDataResult<List<SchoolClassTeacherDto>> GetClassTeacherWithClass();
        IDataResult<SchoolClassTeacher> GetById(int id);
    }
}
