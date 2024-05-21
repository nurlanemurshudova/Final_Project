using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
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
        public IResult Add(TeacherCandidateCreateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = TeacherCandidateCreateDto.ToTeacherCandidate(entity);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _teacherCandidateDal.Add(model);

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

        public IResult Update(TeacherCandidateUpdateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = TeacherCandidateUpdateDto.ToTeacherCandidate(entity);
            var existData = GetById(entity.Id).Data;
            if (photoUrl == null)
            {
                model.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            model.LastUpdateDate = DateTime.Now;
            _teacherCandidateDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
