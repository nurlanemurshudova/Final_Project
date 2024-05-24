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
        public IResult Add(TestimonialCreateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = TestimonialCreateDto.ToTestimonial(entity);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            var validator = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _testmonialDal.Add(model);

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

        public IResult Update(TestimonialUpdateDto entity, IFormFile photoUrl, string webRootPath)
        {
            
            var model = TestimonialUpdateDto.ToTestimonial(entity);
            var existData = GetById(entity.Id).Data;
            if (photoUrl == null)
            {
                model.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            var validator = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            model.LastUpdateDate = DateTime.Now;
            _testmonialDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
