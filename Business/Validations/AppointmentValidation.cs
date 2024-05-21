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
                .WithMessage("Valideyn adı boş ola bilməz")
                .MaximumLength(100)
                .WithMessage("Valideyn adı 100 simvoldan çox ola bilməz");

            RuleFor(x => x.GurdianEmail)
                .NotEmpty()
                .WithMessage("Valideynin e-poçt ünvanı boş ola bilməz")
                .EmailAddress()
                .WithMessage("Doğru e-poçt ünvanı daxil edin");

            RuleFor(x => x.ChildName)
                .NotEmpty()
                .WithMessage("Uşağın adı boş ola bilməz")
                .MaximumLength(100)
                .WithMessage("Uşağın adı 100 simvoldan çox ola bilməz");

            RuleFor(x => x.ChildAge)
                .NotEmpty()
                .WithMessage("Boş ola bilməz");

            RuleFor(x => x.Message)
                .MaximumLength(2000)
                .WithMessage("Mesaj 2000 simvoldan çox ola bilməz");
        }
    }
}
