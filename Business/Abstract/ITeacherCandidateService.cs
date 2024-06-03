using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITeacherCandidateService
    {
        IResult Add(TeacherCandidateCreateDto entity, IFormFile photoUrl, string webRootPath, out Dictionary<string, string> propertyNames);
        IResult Update(TeacherCandidateUpdateDto entity, IFormFile photoUrl, string webRootPath, out Dictionary<string, string> propertyNames);
        IResult Delete(int id);
        IDataResult<List<TeacherCandidate>> GetAll();
        IDataResult<TeacherCandidate> GetById(int id);
    }    

}
