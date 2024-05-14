using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class TeacherCandidateDal : BaseRepository<TeacherCandidate, ApplicationDbContext>,ITeacherCandidateDal { }
}
