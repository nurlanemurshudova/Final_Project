using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Business.Validations
{
    public class SlideValidation : AbstractValidator<Slide>
    {
        public SlideValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Başlıq"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(300, "Başlıq"));

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Açıqlama"))
                .MinimumLength(3)
                .WithMessage(UIMessages.GetMinLengthMessage(3,"Açıqlama"))
                .MaximumLength(1000)
                .WithMessage(UIMessages.GetMaxLengthMessage(1000, "Açıqlama"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Şəkil"));
        }
    }
}
