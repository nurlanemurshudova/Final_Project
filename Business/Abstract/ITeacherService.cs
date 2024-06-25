using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IResult Add(TeacherCreateDto entity, string webRootPath);
        IResult Update(TeacherUpdateDto entity, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Teacher>> GetAll();
        IDataResult<List<TeacherDto>> GetTeacherWithPositions();
        IDataResult<List<TeacherVM>> GetAllTeacherWithDetails();
        IDataResult<TeacherVM> GetByIdTeacherWithDetails(int id);
        IDataResult<Teacher> GetById(int id);
    }    

}
