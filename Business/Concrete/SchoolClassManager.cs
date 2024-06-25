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

        public IResult Add(SchoolClassCreateDto entity, string webRootPath)
        {
            string photo = null;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl,webRootPath);
            }

            SchoolClass schoolClass = new SchoolClass
            {
                Name = entity.Name,
                PhotoUrl = photo,
                ChildAge = entity.ChildAge,
                IsHomePage = entity.IsHomePage,
                Time = entity.Time,
                Capacity = entity.Capacity,
                Price = entity.Price,
            };
            //model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            var validator = ValidationTool.Validate(new SchoolClassValidation(), schoolClass, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            _classDal.Add(schoolClass);
            _classDal.AddWithTeacher(schoolClass, entity);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(SchoolClassUpdateDto entity, string webRootPath)
        {
            var existData = GetByIdClassWithDetails(entity.Id).Data;
            string photo = existData?.PhotoUrl;

            if (entity.PhotoUrl != null && entity.PhotoUrl.Length > 0)
            {
                photo = PictureHelper.UploadImage(entity.PhotoUrl, webRootPath);
            }

            SchoolClass schoolClass = new SchoolClass
            {
                Id = entity.Id,
                Name = entity.Name,
                PhotoUrl = photo,
                ChildAge = entity.ChildAge,
                IsHomePage = entity.IsHomePage,
                Time = entity.Time,
                Capacity = entity.Capacity,
                Price = entity.Price,
            };

            var validator = ValidationTool.Validate(new SchoolClassValidation(), schoolClass, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }

            schoolClass.LastUpdateDate = DateTime.Now;
            _classDal.Update(schoolClass);
            _classDal.UpdateWithTeacher(schoolClass, entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
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


    }
}
