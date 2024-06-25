using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITeacherCandidateService
    {
        IResult Add(TeacherCandidateCreateDto entity, string webRootPath);
        IResult Update(TeacherCandidateUpdateDto entity, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<TeacherCandidate>> GetAll();
        IDataResult<TeacherCandidate> GetById(int id);
    }    

}
