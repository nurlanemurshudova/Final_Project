using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class PositionValidation:AbstractValidator<Position>
    {
        public PositionValidation()
        {
            RuleFor(x => x.Name)
                            .NotEmpty()
                            .WithMessage("Boş ola bilməz")
                            .MinimumLength(3)
                            .WithMessage("3 simvoldan az daxil edilə bilməz")
                            .MaximumLength(100)
                            .WithMessage("100 simvoldan çox ola bilməz");

        }
    }
}
