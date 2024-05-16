using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        AboutDal aboutDal = new ();
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);
            aboutDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);
            model.LastUpdateDate = DateTime.Now;
            aboutDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(aboutDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(aboutDal.GetById(id));
        }
    }
}
