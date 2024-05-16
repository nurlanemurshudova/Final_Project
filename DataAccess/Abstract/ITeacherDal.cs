using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface ITeacherDal : IBaseRepository<Teacher> 
    {
        List<TeacherDto> GetTeacherWithPositions();

    }

}
