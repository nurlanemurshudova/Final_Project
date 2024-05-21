using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class GurdianNumberValidation : AbstractValidator<GurdianNumber>
    {
        public GurdianNumberValidation()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Nömrə boş ola bilməz")
                .MaximumLength(20)
                .WithMessage("Nömrə 20 simvoldan çox ola bilməz")
                .Matches(@"^\+?\d+$")
                .WithMessage("Nömrə yalnız rəqəmlərdən və isteğe bağlı olaraq '+' işarəsindən ibarət olmalıdır");

            RuleFor(x => x.AppontmentId)
                .NotEmpty()
                .WithMessage("AppointmentId boş ola bilməz")
                .GreaterThan(0)
                .WithMessage("AppointmentId 0-dan böyük olmalıdır");
        }
    }
}
