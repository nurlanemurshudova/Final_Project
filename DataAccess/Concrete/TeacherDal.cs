using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TeacherDal : BaseRepository<Teacher, ApplicationDbContext>, ITeacherDal
    {
        private readonly ApplicationDbContext _context;

        public TeacherDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TeacherVM> GetAllClassTeacherWithClass()
        {
            var teacherList = (from t in _context.Teachers
                            join p in _context.Positions on t.PositionId equals p.Id
                            where t.Deleted == 0 && p.Deleted == 0
                            select new TeacherVM
                            {
                                Id = t.Id,
                                Name = t.Name,
                                Surname = t.Surname,
                                InstagramUrl = t.InstagramUrl,
                                FacebookUrl = t.FacebookUrl,
                                TwitterUrl = t.TwitterUrl,
                                PositionId = t.PositionId,
                                PositionName = p.Name,
                                PhotoUrl = t.PhotoUrl,
                                IsHomePage = t.IsHomePage,
                                Experience = t.Experience
                            }).ToList();
            if (teacherList == null && teacherList.Count > 0)
                return teacherList;
            foreach (var teacher in teacherList)
            {
                teacher.SchoolClassTeachers = GetSchoolClassTeachersDetails(teacher, teacher.Id);
            }
            return teacherList;
        }

        public TeacherVM GetByIdClassTeacherWithClass(int id)
        {
            var teacher = (from t in _context.Teachers
                           join p in _context.Positions on t.PositionId equals p.Id
                           where t.Id == id && t.Deleted == 0 && p.Deleted == 0
                           select new TeacherVM
                           {
                               Id = t.Id,
                               Name = t.Name,
                               Surname = t.Surname,
                               InstagramUrl = t.InstagramUrl,
                               FacebookUrl = t.FacebookUrl,
                               TwitterUrl = t.TwitterUrl,
                               PositionId = t.PositionId,
                               PositionName = p.Name,
                               PhotoUrl = t.PhotoUrl,
                               IsHomePage = t.IsHomePage,
                               Experience = t.Experience
                           }).FirstOrDefault();
            if (teacher == null)
                return null;
            teacher.SchoolClassTeachers = GetSchoolClassTeachersDetails(teacher, id);

            return teacher;
        }

        private List<SchoolClassTeacherVM> GetSchoolClassTeachersDetails(TeacherVM teacher, int id)
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

        public List<TeacherDto> GetTeacherWithPositions()
        {
            var result = from teacher in _context.Teachers
                         where teacher.Deleted == 0
                         join position in _context.Positions
                         on teacher.PositionId equals position.Id
                         where position.Deleted == 0
                         select new TeacherDto
                         {
                             Id = teacher.Id,
                             Name = teacher.Name,
                             Surname = teacher.Surname,
                             InstagramUrl = teacher.InstagramUrl,
                             TwitterUrl = teacher.TwitterUrl,
                             FacebookUrl = teacher.FacebookUrl,
                             PositionId = position.Id,
                             Experience = teacher.Experience,
                             IsHomePage = teacher.IsHomePage,
                             PhotoUrl = teacher.PhotoUrl,
                             PositionName = teacher.Name,
                         };

            return result.ToList();
        }
    }
}
