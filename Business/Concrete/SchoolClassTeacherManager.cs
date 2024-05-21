using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class SchoolClassTeacherManager : ISchoolClassTeacherService
    {
        private readonly ISchoolClassTeacherDal _schoolClassTeacherDal;
        public SchoolClassTeacherManager(ISchoolClassTeacherDal schoolClassTeacherDal)
        {
            _schoolClassTeacherDal = schoolClassTeacherDal;
        }
        public IResult Add(SchoolClassTeacher entity)
        {
            _schoolClassTeacherDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _schoolClassTeacherDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<SchoolClassTeacher> GetById(int id)
        {
            return new SuccessDataResult<SchoolClassTeacher>(_schoolClassTeacherDal.GetById(id));
        }

        public IDataResult<List<SchoolClassTeacherDto>> GetClassTeacherWithClass()
        {
            throw new NotImplementedException();
        }

        //public IDataResult<List<SchoolClassTeacherDto>> GetClassTeacherWithClass()
        //{
        //    //return new SuccessDataResult<List<SchoolClassTeacherDto>>(_schoolClassTeacherDal.GetClassTeacherWithClass());
        //}

        public IResult Update(SchoolClassTeacher entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _schoolClassTeacherDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
