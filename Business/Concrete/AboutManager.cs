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
    public class AboutManager : IAboutService
    {
        private readonly IValidator<About> _validator;
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal,IValidator<About> validator)
        {
            _validator = validator;
            _aboutDal = aboutDal;
        }
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);
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
            _aboutDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);
            model.LastUpdateDate = DateTime.Now;
            _aboutDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetById(id));
        }
    }
}
