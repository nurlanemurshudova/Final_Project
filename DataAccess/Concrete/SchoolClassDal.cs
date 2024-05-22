using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class SchoolClassDal : BaseRepository<SchoolClass, ApplicationDbContext>, ISchoolClassDal
    {
        private readonly ApplicationDbContext _context;

        public SchoolClassDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SchoolClassVM> GetAllClassTeacherWithClass()
        {
            var classes = (from sc in _context.SchoolClasses
                           where sc.Deleted == 0
                           select new SchoolClassVM
                           {
                               Id = sc.Id,
                               Name = sc.Name,
                               ChildAge = sc.ChildAge,
                               IsHomePage = sc.IsHomePage,
                               Time = sc.Time,
                               Capacity = sc.Capacity,
                               Price = sc.Price,
                               PhotoUrl = sc.PhotoUrl,
                           }).ToList();
            if (classes == null && classes.Count > 0)
                return classes;
            foreach (var schoolClass in classes)
            {
                schoolClass.SchoolClassTeachers = GetSchoolClassTeachersDetails(schoolClass, schoolClass.Id);
            }
            return classes;
        }

        public SchoolClassVM GetByIdClassTeacherWithClass(int id)
        {
            var schoolClass = (from sc in _context.SchoolClasses
                               where sc.Deleted == 0
                               select new SchoolClassVM
                               {
                                   Id = sc.Id,
                                   Name = sc.Name,
                                   ChildAge = sc.ChildAge,
                                   IsHomePage = sc.IsHomePage,
                                   Time = sc.Time,
                                   Capacity = sc.Capacity,
                                   Price = sc.Price,
                                   PhotoUrl = sc.PhotoUrl,
                               }).FirstOrDefault();
            if (schoolClass == null)
                return null;
            schoolClass.SchoolClassTeachers = GetSchoolClassTeachersDetails(schoolClass, id);

            return schoolClass;
        }

        private List<SchoolClassTeacherVM> GetSchoolClassTeachersDetails(SchoolClassVM schoolClass, int id)
        {
            return (from scT in _context.SchoolClassTeachers
                    join sc in _context.SchoolClasses on scT.SchoolClassId equals sc.Id
                    join t in _context.Teachers on scT.TeacherId equals t.Id
                    where t.Id == id && t.Deleted == 0 && scT.Deleted == 0 && sc.Deleted == 0
                    select new SchoolClassTeacherVM
                    {
                        TeacherId = t.Id,
                        TeacherName = t.Name,
                        SchoolClassId = sc.Id,
                        SchoolClassName = sc.Name
                    }).ToList();
        }
    }
}
