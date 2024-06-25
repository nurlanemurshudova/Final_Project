using Business.Abstract;
using Business.BaseMessages;
using Business.Validations;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal) 
        {
            _teacherDal = teacherDal;
        }
        public IResult Add(TeacherCreateDto entity, string webRootPath)
        {
            string photo = null;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            Teacher teacher = new Teacher()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                InstagramUrl = entity.InstagramUrl,
                FacebookUrl = entity.FacebookUrl,
                TwitterUrl = entity.TwitterUrl,
                PositionId = entity.PositionId,
                PhotoUrl = photo,
                IsHomePage = entity.IsHomePage,
                Experience = entity.Experience,
            };
            var validator = ValidationTool.Validate(new TeacherValidation(), teacher, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            _teacherDal.Add(teacher);

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

        public IResult Update(TeacherUpdateDto entity, string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            string photo = existData?.PhotoUrl;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            Teacher teacher = new Teacher()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                InstagramUrl = entity.InstagramUrl,
                FacebookUrl = entity.FacebookUrl,
                TwitterUrl = entity.TwitterUrl,
                PositionId = entity.PositionId,
                PhotoUrl = photo,
                IsHomePage = entity.IsHomePage,
                Experience = entity.Experience,
            };
            var validator = ValidationTool.Validate(new TeacherValidation(), teacher, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            teacher.LastUpdateDate = DateTime.Now;
            _teacherDal.Update(teacher);

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


        public IDataResult<List<Teacher>> GetAll()
        {
            return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll(x => x.Deleted == 0));

        }
    }
}
