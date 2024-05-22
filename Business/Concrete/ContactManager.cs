using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;
        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _validator = validator;
            _contactDal = contactDal;
        }
        public IResult Add(ContactCreateDto entity, out Dictionary<string, string> propertyNames)
        {
            var model = ContactCreateDto.ToContact(entity);
            var validator = _validator.Validate(model);
            if (!validator.IsValid)
            {
                propertyNames = new();
                foreach (var item in validator.Errors)
                {
                    propertyNames.Add(item.PropertyName, item.ErrorMessage);
                }
                return new ErrorResult();
            }
            propertyNames = null;
            _contactDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        //public IResult Add(ContactCreateDto entity)
        //{
        //    var model = ContactCreateDto.ToContact(entity);
        //    var validator = _validator.Validate(model);

        //    string errorMessage = " ";
        //    foreach (var item in validator.Errors)
        //    {
        //        errorMessage = item.ErrorMessage;
        //        //propertyNames += item.PropertyName;
        //    }

        //    if (!validator.IsValid)
        //    {
        //        return new ErrorResult(errorMessage);
        //    }
        //    _contactDal.Add(model);

        //    return new SuccessResult(UIMessages.ADDED_MESSAGE);
        //}

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _contactDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetById(id));
        }

        public IResult Update(ContactUpdateDto entity)
        {
            var model = ContactUpdateDto.ToContact(entity);
            model.LastUpdateDate = DateTime.Now;
            _contactDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
