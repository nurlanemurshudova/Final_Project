using Business.BaseMessages;
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
                .WithMessage(UIMessages.GetRequiredMessage("Nömrə"))
                .MaximumLength(20)
                .WithMessage(UIMessages.GetMaxLengthMessage(20, "Nömrə"))
                .Matches(@"^\+?\d+$")
                .WithMessage("Nömrə yalnız rəqəmlərdən və ya '+' işarəsindən ibarət olmalıdır");

            RuleFor(x => x.AppontmentId)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage(""));
        }
    }
}
