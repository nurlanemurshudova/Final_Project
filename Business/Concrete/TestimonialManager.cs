using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
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
        public IResult Add(TestimonialCreateDto entity)
        {
            var model = TestimonialCreateDto.ToTestimonial(entity);
            //model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
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

        public IResult Update(TestimonialUpdateDto entity)
        {
            
            var model = TestimonialUpdateDto.ToTestimonial(entity);
            var existData = GetById(entity.Id).Data;
            //if (photoUrl == null)
            //{
            //    model.PhotoUrl = existData.PhotoUrl;
            //}
            //else
            //{
            //    model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            //}
            model.LastUpdateDate = DateTime.Now;
            _testmonialDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
