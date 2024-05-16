using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TeacherDal : BaseRepository<Teacher, ApplicationDbContext>, ITeacherDal
    {
        ApplicationDbContext _context = new();
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
                             PositionName = teacher.Name
                         };

            return result.ToList();
        }
    }
}
