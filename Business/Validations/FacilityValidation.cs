using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class FacilityValidation : AbstractValidator<Facility>
    {
        public FacilityValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Ad"));

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"))
                .MaximumLength(1000)
                .WithMessage(UIMessages.GetMaxLengthMessage(1000, "Açıqlama"));

            RuleFor(x => x.IconName)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("İkon adı"))
                .MaximumLength(150)
                .WithMessage(UIMessages.GetMaxLengthMessage(150, "İkon adı"));
        }
    }
}
