using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }
        public IResult Add(PositionCreateDto entity)
        {
            var model = PositionCreateDto.ToPosition(entity);
            _positionDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _positionDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.GetById(id));

        }

        public IResult Update(PositionUpdateDto entity)
        {
            var model = PositionUpdateDto.ToPosition(entity);
            model.LastUpdateDate = DateTime.Now;
            _positionDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
