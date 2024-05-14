using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class SchoolClassManager : ISchoolClassService
    {
        SchoolClassDal classDal = new();
        public IResult Add(SchoolClass entity)
        {
            classDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            classDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<SchoolClass>> GetAll()
        {
            return new SuccessDataResult<List<SchoolClass>>(classDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<SchoolClass> GetById(int id)
        {
            return new SuccessDataResult<SchoolClass>(classDal.GetById(id));

        }

        public IResult Update(SchoolClass entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            classDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
