using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Abstract
{
    public interface ISchoolClassTeacherDal : IBaseRepository<SchoolClassTeacher>
    {
        List<SchoolClassTeacherVM> GetAllClassTeacherWithClass();
        SchoolClassTeacherVM GetByIdClassTeacherWithClass(int id);
    }
}