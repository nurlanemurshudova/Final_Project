using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ISchoolClassService
    {
        IResult Add(SchoolClassCreateDto entity, IFormFile photoUrl, string webRootPath);
        IResult Update(SchoolClassUpdateDto entity, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<SchoolClass>> GetAll();
        IDataResult<List<SchoolClassVM>> GetAllClassWithDetails();
        IDataResult<SchoolClassVM> GetByIdClassWithDetails(int id);
        IDataResult<SchoolClass> GetById(int id);
    }    


}
