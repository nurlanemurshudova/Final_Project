using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace DataAccess.Concrete
{
    public class SchoolClassTeacherDal : BaseRepository<SchoolClassTeacher, ApplicationDbContext>, ISchoolClassTeacherDal
    {
        private readonly ApplicationDbContext _context;

        public SchoolClassTeacherDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SchoolClassTeacherVM> GetAllClassTeacherWithClass()
        {
            throw new NotImplementedException();
        }

        public SchoolClassTeacherVM GetByIdClassTeacherWithClass(int id)
        {
            throw new NotImplementedException();
        }

        public List<SchoolClassTeacherDto> GetClassTeacherWithClass()
        {

            var result = from crossTable in _context.SchoolClassTeachers
                         from teacher in _context.Teachers
                         where teacher.Deleted == 0
                         join @class in _context.SchoolClasses
                         on teacher.Id equals @class.Id
                         where @class.Deleted == 0
                         select new SchoolClassTeacherDto
                         {
                             Id = crossTable.Id,
                             TeacherId = teacher.Id,
                             SchoolClassId = @class.Id,
                         };

            return result.ToList();
        }
    }
}
