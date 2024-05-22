using Business.Abstract;
using Business.BaseMessages;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class SchoolClassManager : ISchoolClassService
    {
        private readonly ISchoolClassDal _classDal;
        public SchoolClassManager(ISchoolClassDal classDal)
        {
            _classDal = classDal;
        }

        public IResult Add(SchoolClassCreateDto entity, IFormFile photoUrl, string webRootPath)
        {
            //classDal.Add(entity);
            var model = SchoolClassCreateDto.ToSchoolClass(entity);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _classDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _classDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<SchoolClass>> GetAll()
        {
            return new SuccessDataResult<List<SchoolClass>>(_classDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<List<SchoolClassVM>> GetAllClassWithDetails()
        {
            return new SuccessDataResult<List<SchoolClassVM>>(_classDal.GetAllClassTeacherWithClass());
        }

        public IDataResult<SchoolClass> GetById(int id)
        {
            return new SuccessDataResult<SchoolClass>(_classDal.GetById(id));

        }

        public IDataResult<SchoolClassVM> GetByIdClassWithDetails(int id)
        {
            return new SuccessDataResult<SchoolClassVM>(_classDal.GetByIdClassTeacherWithClass(id));
        }

        public IResult Update(SchoolClassUpdateDto entity, IFormFile photoUrl, string webRootPath)
        {
            var model = SchoolClassUpdateDto.ToSchoolClass(entity);
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
            _classDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
