using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.Description)
                            .NotEmpty()
                            .WithMessage("Boş ola bilməz")
                            .MinimumLength(3)
                            .WithMessage("3 simvoldan az daxil edilə bilməz")
                            .MaximumLength(2000)
                            .WithMessage("2000 simvoldan çox ola bilməz");

        }
    }
}
