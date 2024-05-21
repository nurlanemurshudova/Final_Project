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
                .WithMessage("Ad boş ola bilməz")
                .MaximumLength(100)
                .WithMessage("Ad 100 simvoldan çox ola bilməz");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıqlama boş ola bilməz")
                .MaximumLength(1000)
                .WithMessage("Açıqlama 1000 simvoldan çox ola bilməz");

            RuleFor(x => x.IconName)
                .NotEmpty()
                .WithMessage("İkon adı boş ola bilməz")
                .MaximumLength(150)
                .WithMessage("İkon adı 150 simvoldan çox ola bilməz");
        }
    }
}
