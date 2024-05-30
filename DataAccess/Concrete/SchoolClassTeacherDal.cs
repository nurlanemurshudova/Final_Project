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
            var classTeacherList = (from scT in _context.SchoolClassTeachers
                                    join sc in _context.SchoolClasses on scT.SchoolClassId equals sc.Id
                                    join t in _context.Teachers on scT.TeacherId equals t.Id
                                    where scT.Deleted == 0 && sc.Deleted == 0 && t.Deleted == 0
                                    select new SchoolClassTeacherVM
                                    {
                                        Id = scT.Id,
                                        TeacherId = t.Id,
                                        TeacherName = t.Name,
                                        SchoolClassId = sc.Id,
                                        SchoolClassName = sc.Name
                                    }).ToList();

            return classTeacherList;
        }

        public SchoolClassTeacherVM GetByIdClassTeacherWithClass(int id)
        {
            var classTeacher = (from scT in _context.SchoolClassTeachers
                                join sc in _context.SchoolClasses on scT.SchoolClassId equals sc.Id
                                join t in _context.Teachers on scT.TeacherId equals t.Id
                                where scT.Id == id && scT.Deleted == 0 && sc.Deleted == 0 && t.Deleted == 0
                                select new SchoolClassTeacherVM
                                {
                                   // Id = id,
                                    TeacherId = t.Id,
                                    TeacherName = t.Name,
                                    SchoolClassId = sc.Id,
                                    SchoolClassName = sc.Name
                                }).FirstOrDefault();

            return classTeacher;
        }

    }
}
