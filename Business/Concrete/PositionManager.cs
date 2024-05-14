using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        PositionDal positionDal = new();
        public IResult Add(Position entity)
        {
            positionDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            positionDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(positionDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(positionDal.GetById(id));

        }

        public IResult Update(Position entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            positionDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
