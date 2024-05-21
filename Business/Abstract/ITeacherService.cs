using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IResult Add(TeacherCreateDto entity);
        IResult Update(TeacherUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<TeacherDto>> GetTeacherWithPositions();
        IDataResult<List<TeacherVM>> GetAllTeacherWithDetails();
        IDataResult<TeacherVM> GetByIdTeacherWithDetails(int id);
        IDataResult<Teacher> GetById(int id);
    }    

}
