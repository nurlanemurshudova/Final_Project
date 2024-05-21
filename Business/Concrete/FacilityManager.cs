using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class FacilityManager : IFacilityService
    {
        private readonly IFacilityDal _facilityDal;
        private readonly IValidator<Facility> _validator;
        public FacilityManager(IFacilityDal facilityDal,IValidator<Facility> validator) 
        {
            _facilityDal = facilityDal;
            _validator = validator;
        }
        public IResult Add(FacilityCreateDto entity)
        {
            var model = FacilityCreateDto.ToFacility(entity);
            var validator = _validator.Validate(model);

            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
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
            model.LastUpdateDate = DateTime.Now;
            _facilityDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }
    }
}
