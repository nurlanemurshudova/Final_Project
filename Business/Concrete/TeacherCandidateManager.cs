using Business.Abstract;
using Business.BaseMessages;
using Business.Validations;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TeacherCandidateManager : ITeacherCandidateService
    {
        private readonly ITeacherCandidateDal _teacherCandidateDal;
        public TeacherCandidateManager(ITeacherCandidateDal teacherCandidateDal)
        {
            _teacherCandidateDal = teacherCandidateDal;
        }
        public IResult Add(TeacherCandidateCreateDto entity, string webRootPath)
        {
            string photo = null;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }
            TeacherCandidate teacherCandidate = new TeacherCandidate()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                BirthDate = entity.BirthDate,
                Experience = entity.Experience,
                Education = entity.Education,
                PhotoUrl = photo,
                IsContacted = entity.IsContacted,
            };
            var validator = ValidationTool.Validate(new TeacherCandidateValidation(), teacherCandidate, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            _teacherCandidateDal.Add(teacherCandidate);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _teacherCandidateDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<TeacherCandidate>> GetAll()
        {
            return new SuccessDataResult<List<TeacherCandidate>>(_teacherCandidateDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<TeacherCandidate> GetById(int id)
        {
            return new SuccessDataResult<TeacherCandidate>(_teacherCandidateDal.GetById(id));
        }

        public IResult Update(TeacherCandidateUpdateDto entity, string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            string photo = existData?.PhotoUrl;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }


            TeacherCandidate teacherCandidate = new TeacherCandidate()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                BirthDate = entity.BirthDate,
                Experience = entity.Experience,
                Education = entity.Education,
                PhotoUrl = photo,
                IsContacted = entity.IsContacted,
            };
            var validator = ValidationTool.Validate(new TeacherCandidateValidation(), teacherCandidate, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            teacherCandidate.LastUpdateDate = DateTime.Now;
            _teacherCandidateDal.Update(teacherCandidate);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
