using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        //IResult Add(TestimonialCreateDto entity, IFormFile photoUrl, string webRootPath);
        //IResult Update(TestimonialUpdateDto entity, IFormFile photoUrl, string webRootPath);
        //IResult Delete(int id);
        //IDataResult<List<Testimonial>> GetAll();
        //IDataResult<Testimonial> GetById(int id);

        IResult Add(TestimonialCreateDto entity);
        IResult Update(TestimonialUpdateDto entity);
        IResult Delete(int id);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<Testimonial> GetById(int id);
    }    
}
