using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class SlideManager : ISlideService
    {
        SlideDal slideDal = new();
        public IResult Add(Slide entity)
        {
            slideDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            slideDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Slide>> GetAll()
        {
            return new SuccessDataResult<List<Slide>>(slideDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<Slide> GetById(int id)
        {
            return new SuccessDataResult<Slide>(slideDal.GetById(id));

        }

        public IResult Update(Slide entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            slideDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
