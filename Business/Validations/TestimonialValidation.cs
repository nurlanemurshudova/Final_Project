using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class TestimonialValidation : AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                 .MinimumLength(2)
                 .WithMessage(UIMessages.GetMinLengthMessage(2, "Ad"))
                 .MaximumLength(100)
                 .WithMessage(UIMessages.GetMaxLengthMessage(100, "Ad"));

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Soyad"))
                .MinimumLength(2)
                .WithMessage(UIMessages.GetMinLengthMessage(2, "Soyad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100, "Soyad"));

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Şəkil"));

            RuleFor(x => x.Feedback)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Rəy"))
                .MaximumLength(2000)
                .WithMessage(UIMessages.GetMaxLengthMessage(2000, "Rəy"));


        }
    }
}