using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Abstract
{
    public interface ITeacherDal : IBaseRepository<Teacher> 
    {
        List<TeacherDto> GetTeacherWithPositions();
        List<TeacherVM> GetAllClassTeacherWithClass();
        TeacherVM GetByIdClassTeacherWithClass(int id);
    }

}
