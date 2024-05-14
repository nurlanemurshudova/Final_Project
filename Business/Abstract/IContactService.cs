using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact entity);
        IResult Update(Contact entity);
        IResult Delete(int id);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
    }
}
