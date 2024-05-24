using Business.Abstract;
using Business.BaseMessages;
using Business.Validations;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class GurdianNumberManager : IGurdianNumberService
    {
        private readonly IGurdianNumberDal _gurdianNumberDal;

        public GurdianNumberManager(IGurdianNumberDal gurdianNumberDal)
        {
            _gurdianNumberDal = gurdianNumberDal;
        }

        public IResult Add(GurdianNumberCreateDto entity, out Dictionary<string, string> propertyNames)
        {
            var model = GurdianNumberCreateDto.ToGurdianNumber(entity);
            var validator = ValidationTool.Validate(new GurdianNumberValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                propertyNames = new();
                foreach (var item in errors)
                {
                    propertyNames.Add(item.PropertyName, item.ErrorMessage);
                }
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _gurdianNumberDal.Add(model);
            propertyNames = null;
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _gurdianNumberDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<GurdianNumberDto>> GetNumberWithAppointments()
        {
            return new SuccessDataResult<List<GurdianNumberDto>>(_gurdianNumberDal.GetNumberWithAppointments());
        }

        public IDataResult<GurdianNumber> GetById(int id)
        {
            return new SuccessDataResult<GurdianNumber>(_gurdianNumberDal.GetById(id));
        }

        public IResult Update(GurdianNumberUpdateDto entity, out Dictionary<string, string> propertyNames)
        {
            var model = GurdianNumberUpdateDto.ToGurdianNumber(entity);
            var validator = ValidationTool.Validate(new GurdianNumberValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                propertyNames = new();
                foreach (var item in errors)
                {
                    propertyNames.Add(item.PropertyName, item.ErrorMessage);
                }
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            propertyNames = null;
            model.LastUpdateDate = DateTime.Now;
            _gurdianNumberDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
