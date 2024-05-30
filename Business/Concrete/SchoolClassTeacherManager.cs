using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace Business.Concrete
{
    public class SchoolClassTeacherManager : ISchoolClassTeacherService
    {
        private readonly ISchoolClassTeacherDal _schoolClassTeacherDal;
        public SchoolClassTeacherManager(ISchoolClassTeacherDal schoolClassTeacherDal)
        {
            _schoolClassTeacherDal = schoolClassTeacherDal;
        }
        public IResult Add(SchoolClassTeacherCreateDto entity)
        {
            var model = SchoolClassTeacherCreateDto.ToClassTeacher(entity);
            _schoolClassTeacherDal.Add(model);

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

        public IDataResult<List<SchoolClassTeacher>> GetAll()
        {
            return new SuccessDataResult<List<SchoolClassTeacher>>(_schoolClassTeacherDal.GetAll(x => x.Deleted == 0));

        }

        //public IDataResult<List<SchoolClassTeacherDto>> GetClassTeacherWithClass()
        //{
        //    //return new SuccessDataResult<List<SchoolClassTeacherDto>>(_schoolClassTeacherDal.GetClassTeacherWithClass());
        //}

        public IResult Update(SchoolClassTeacherUpdateDto entity)
        {
            var model = SchoolClassTeacherUpdateDto.ToClassTeacher(entity);
            model.LastUpdateDate = DateTime.Now;
            _schoolClassTeacherDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IDataResult<List<SchoolClassTeacherVM>> GetAllClassTeacherWithClass()
        {
            return new SuccessDataResult<List<SchoolClassTeacherVM>>(_schoolClassTeacherDal.GetAllClassTeacherWithClass());
        }

        public IDataResult<SchoolClassTeacherVM> GetByIdClassTeacherWithClass(int id)
        {
            return new SuccessDataResult<SchoolClassTeacherVM>(_schoolClassTeacherDal.GetByIdClassTeacherWithClass(id));
        }
    }
}
