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
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class SlideManager : ISlideService
    {
        private readonly ISlideDal _slideDal;
        public SlideManager(ISlideDal slideDal)
        {
            _slideDal = slideDal;
        }
        public IResult Add(SlideCreateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = SlideCreateDto.ToSlide(entity);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            var validator = ValidationTool.Validate(new SlideValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _slideDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _slideDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Slide>> GetAll()
        {
            return new SuccessDataResult<List<Slide>>(_slideDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<Slide> GetById(int id)
        {
            return new SuccessDataResult<Slide>(_slideDal.GetById(id));

        }

        public IResult Update(SlideUpdateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = SlideUpdateDto.ToSlide(entity);
            var existData = GetById(entity.Id).Data;
            if (photoUrl == null)
            {
                model.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            var validator = ValidationTool.Validate(new SlideValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            model.LastUpdateDate = DateTime.Now;
            _slideDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
