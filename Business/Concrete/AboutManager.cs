using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        AboutDal aboutDal = new ();
        public IResult Add(About entity)
        {
            aboutDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(About entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            aboutDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            aboutDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
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
