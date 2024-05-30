using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace Business.Abstract
{
    public interface ISchoolClassTeacherService
    {
        IResult Add(SchoolClassTeacherCreateDto entity);
        IResult Update(SchoolClassTeacherUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<SchoolClassTeacher>> GetAll();
        IDataResult<List<SchoolClassTeacherVM>> GetAllClassTeacherWithClass();
        IDataResult<SchoolClassTeacherVM> GetByIdClassTeacherWithClass(int id);
        IDataResult<SchoolClassTeacher> GetById(int id);
    }
}
