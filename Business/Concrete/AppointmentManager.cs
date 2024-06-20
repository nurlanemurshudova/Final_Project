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
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;
       
        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public IResult Add(AppointmentCreateDto entity)
        {
            //var model = AppointmentCreateDto.ToAppointment(entity);
            //var validator = ValidationTool.Validate(new AppointmentValidation(), model, out List<ValidationErrorModel> errors);

            //if (!validator)
            //{
            //    propertyNames = new();
            //    foreach (var item in errors)
            //    {
            //        propertyNames.Add(item.PropertyName, item.ErrorMessage);
            //    }
            //    return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            //}
            //propertyNames = null;
            //_appointmentDal.Add(model);
            //foreach (var gurdianNumber in model.GurdianNumbers)
            //{
            //    gurdianNumber.AppontmentId = model.Id;
            //    _numberDal.Add(gurdianNumber);
            //}
            //return new SuccessResult(UIMessages.ADDED_MESSAGE);

            var model = AppointmentCreateDto.ToAppointment(entity);
            var validator = ValidationTool.Validate(new AppointmentValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                //var errorMessage = string.Join(Environment.NewLine, errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                //return new ErrorResult(errorMessage);


                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);

                //return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _appointmentDal.Add(model);
            //foreach (var gurdianNumber in model.GurdianNumbers)
            //{
            //    gurdianNumber.AppontmentId = model.Id;
            //    _numberDal.Add(gurdianNumber);
            //}
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _appointmentDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Appointment>> GetAll()
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Appointment> GetById(int id)
        {
            return new SuccessDataResult<Appointment>(_appointmentDal.GetById(id));
        }

        public IResult Update(AppointmentUpdateDto entity)
        {
            var model = AppointmentUpdateDto.ToAppointment(entity);
            var validator = ValidationTool.Validate(new AppointmentValidation(), model, out List<ValidationErrorModel> errors);


            if (!validator)
            {
                //var errorMessage = string.Join(Environment.NewLine, errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                //return new ErrorResult(errorMessage);


                var error = errors.Select(e => new ValidationErrorModel
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return new ErrorResult(error);

                //return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            model.LastUpdateDate = DateTime.Now;
            _appointmentDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
