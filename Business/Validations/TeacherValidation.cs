using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class TeacherValidation : AbstractValidator<Teacher>
    {
        public TeacherValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MinimumLength(2)
                .WithMessage(UIMessages.GetMinLengthMessage(2, "Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"));

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Soyad"))
                .MinimumLength(2)
                .WithMessage(UIMessages.GetMinLengthMessage(2, "Soyad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Soyad"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Şəkil"));

            RuleFor(x => x.Experience)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Təcrübə"));

        }
    }
}