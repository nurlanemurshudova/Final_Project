using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Abstract
{
    public interface ISchoolClassDal : IBaseRepository<SchoolClass>
    {
        List<SchoolClassVM> GetAllClassTeacherWithClass();
        SchoolClassVM GetByIdClassTeacherWithClass(int id);
    }

}
