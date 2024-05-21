using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(ContactCreateDto entity);
        IResult Update(ContactUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
    }
}
