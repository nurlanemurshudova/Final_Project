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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal) 
        {
            _teacherDal = teacherDal;
        }
        public IResult Add(TeacherCreateDto entity)
        {
            var model = TeacherCreateDto.ToTeacher(entity);
            _teacherDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _teacherDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<TeacherDto>> GetTeacherWithPositions()
        {
            return new SuccessDataResult<List<TeacherDto>>(_teacherDal.GetTeacherWithPositions());
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.GetById(id));
        }

        public IResult Update(TeacherUpdateDto entity)
        {
            var model = TeacherUpdateDto.ToTeacher(entity);
            model.LastUpdateDate = DateTime.Now;
            _teacherDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IDataResult<List<TeacherVM>> GetAllTeacherWithDetails()
        {
            return new SuccessDataResult<List<TeacherVM>>(_teacherDal.GetAllClassTeacherWithClass());
        }

        public IDataResult<TeacherVM> GetByIdTeacherWithDetails(int id)
        {
            return new SuccessDataResult<TeacherVM>(_teacherDal.GetByIdClassTeacherWithClass(id));
        }
    }
}
