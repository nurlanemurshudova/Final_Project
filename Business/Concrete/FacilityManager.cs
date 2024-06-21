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
using FluentValidation;

namespace Business.Concrete
{
    public class FacilityManager : IFacilityService
    {
        private readonly IFacilityDal _facilityDal;
        public FacilityManager(IFacilityDal facilityDal) 
        {
            _facilityDal = facilityDal;
        }
        public IResult Add(FacilityCreateDto entity)
        {
            var model = FacilityCreateDto.ToFacility(entity);
            var validator = ValidationTool.Validate(new FacilityValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            _facilityDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);

        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _facilityDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<Facility>> GetAll()
        {
            return new SuccessDataResult<List<Facility>>(_facilityDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Facility> GetById(int id)
        {
            return new SuccessDataResult<Facility>(_facilityDal.GetById(id));
        }

        public IResult Update(FacilityUpdateDto entity)
        {
            var model = FacilityUpdateDto.ToFacility(entity);
            var validator = ValidationTool.Validate(new FacilityValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);
            }
            model.LastUpdateDate = DateTime.Now;
            _facilityDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }
    }
}
