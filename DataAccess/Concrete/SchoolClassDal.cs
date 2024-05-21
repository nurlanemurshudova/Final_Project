using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Concrete
{
    public class SchoolClassDal : BaseRepository<SchoolClass, ApplicationDbContext>, ISchoolClassDal
    {
        public List<SchoolClassVM> GetAllClassTeacherWithClass()
        {
            throw new NotImplementedException();
        }

        public SchoolClassVM GetByIdClassTeacherWithClass(int id)
        {
            throw new NotImplementedException();
        }
    }
}
