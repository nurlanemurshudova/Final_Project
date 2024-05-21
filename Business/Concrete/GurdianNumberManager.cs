using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class GurdianNumberManager : IGurdianNumberService
    {
        private readonly IGurdianNumberDal _gurdianNumberDal;
        private readonly IValidator<GurdianNumber> _validator;

        public GurdianNumberManager(IGurdianNumberDal gurdianNumberDal,IValidator<GurdianNumber> validator)
        {
            _gurdianNumberDal = gurdianNumberDal;
            _validator = validator;
        }

        public IResult Add(GurdianNumberCreateDto entity)
        {
            var model = GurdianNumberCreateDto.ToGurdianNumber(entity);
            var validator = _validator.Validate(model);

            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _gurdianNumberDal.Add(model);

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

        public IResult Update(GurdianNumberUpdateDto entity)
        {
            var model = GurdianNumberUpdateDto.ToGurdianNumber(entity);
            model.LastUpdateDate = DateTime.Now;
            _gurdianNumberDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
