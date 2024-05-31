using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class SchoolClassValidation : AbstractValidator<SchoolClass>
    {
        public SchoolClassValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"));

            RuleFor(x => x.ChildAge)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Uşaq yaşı"));

            RuleFor(x => x.Time)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Tarix"));

            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Uşaq sayı"))
                .GreaterThan((byte)0)
                .WithMessage("Uşaq sayı sıfırdan böyük olmalıdır")
                .LessThanOrEqualTo((byte)50)
                .WithMessage("Uşaq sayı 50-dən çox ola bilməz");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Qiymət sıfırdan böyük olmalıdır")
                .LessThanOrEqualTo(1000)
                .WithMessage("Qiymət 1000-dən böyük ola bilməz");

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Şəkil URL boş ola bilməz");

            //RuleFor(x => x.SchoolClassTeachers)
            //    .NotEmpty()
            //    .WithMessage(UIMessages.GetRequiredMessage("Müəllim"));

        }
    }
}