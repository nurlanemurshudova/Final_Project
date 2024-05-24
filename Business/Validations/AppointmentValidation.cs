using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class AppointmentValidation : AbstractValidator<Appointment>
    {
        public AppointmentValidation()
        {
            RuleFor(x => x.GurdianName)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Valideyn adı"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Valideyn adı"));

            RuleFor(x => x.GurdianEmail)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Email"))
                .EmailAddress()
                .WithMessage(UIMessages.GetEmailErrorMessage());

            RuleFor(x => x.ChildName)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Uşağın adı"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Uşağın adı"));

            RuleFor(x => x.ChildAge)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Uşağın yaşı"));

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Mesaj"))
                .MaximumLength(2000)
                .WithMessage(UIMessages.GetMaxLengthMessage(2000,"Mesaj"));
        }
    }
}
