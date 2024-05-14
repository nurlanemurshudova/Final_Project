using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ITeacherCandidateService
    {
        IResult Add(TeacherCandidate entity);
        IResult Update(TeacherCandidate entity);
        IResult Delete(int id);
        IDataResult<List<TeacherCandidate>> GetAll();
        IDataResult<TeacherCandidate> GetById(int id);
    }    

}
