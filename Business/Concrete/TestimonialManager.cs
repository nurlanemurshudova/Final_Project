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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestmonialDal _testmonialDal;
        public TestimonialManager(ITestmonialDal testmonialDal) 
        {
            _testmonialDal = testmonialDal;
        }
        public IResult Add(TestimonialCreateDto entity, string webRootPath)
        {
            string photo = null;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }
            Testimonial testimonial = new Testimonial()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Feedback = entity.Feedback,
                PhotoUrl = photo,
            };
            var validator = ValidationTool.Validate(new TestimonialValidation(), testimonial, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            _testmonialDal.Add(testimonial);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _testmonialDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testmonialDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Testimonial> GetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testmonialDal.GetById(id));
        }

        public IResult Update(TestimonialUpdateDto entity,  string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            string photo = existData?.PhotoUrl;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            Testimonial testimonial = new Testimonial()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Feedback = entity.Feedback,
                PhotoUrl = photo,
            };

            var validator = ValidationTool.Validate(new TestimonialValidation(), testimonial, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            testimonial.LastUpdateDate = DateTime.Now;
            _testmonialDal.Update(testimonial);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
