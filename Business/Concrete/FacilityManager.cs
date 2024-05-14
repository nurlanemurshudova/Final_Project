using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class FacilityManager : IFacilityService
    {
        FacilityDal facilityDal = new ();
        public IResult Add(Facility entity)
        {
            facilityDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);

        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            facilityDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<Facility>> GetAll()
        {
            return new SuccessDataResult<List<Facility>>(facilityDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Facility> GetById(int id)
        {
            return new SuccessDataResult<Facility>(facilityDal.GetById(id));
        }

        public IResult Update(Facility entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            facilityDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }
    }
}
