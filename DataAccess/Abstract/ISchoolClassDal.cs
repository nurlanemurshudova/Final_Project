using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Abstract
{
    public interface ISchoolClassDal : IBaseRepository<SchoolClass>
    {
        List<SchoolClassVM> GetAllClassTeacherWithClass();
        SchoolClassVM GetByIdClassTeacherWithClass(int id);
        void AddWithTeacher(SchoolClass schoolClass, SchoolClassCreateDto dto);
        void UpdateWithTeacher(SchoolClass schoolClass, SchoolClassUpdateDto dto);
    }

}
