using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class GurdianNumberManager : IGurdianNumberService
    {
        GurdianNumberDal numberDal = new();
        public IResult Add(GurdianNumber entity)
        {
            numberDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            numberDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<GurdianNumberDto>> GetNumberWithAppointments()
        {
            return new SuccessDataResult<List<GurdianNumberDto>>(numberDal.GetNumberWithAppointments());
        }

        public IDataResult<GurdianNumber> GetById(int id)
        {
            return new SuccessDataResult<GurdianNumber>(numberDal.GetById(id));
        }

        public IResult Update(GurdianNumber entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            numberDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
