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
        public IResult Add(SlideCreateDto entity, string webRootPath)
        {
            string photo = null;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            Slide slide = new Slide()
            {
                Title = entity.Title,
                Description = entity.Description,
                PhotoUrl = photo,
            };

            var validator = ValidationTool.Validate(new SlideValidation(), slide, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }

            _slideDal.Add(slide);
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

        public IResult Update(SlideUpdateDto entity, string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            string photo = existData?.PhotoUrl;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            Slide slide = new Slide()
            {
                Title = entity.Title,
                Description = entity.Description,
                PhotoUrl = photo,
            };

            var validator = ValidationTool.Validate(new SlideValidation(), slide, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            slide.LastUpdateDate = DateTime.Now;
            _slideDal.Update(slide);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
