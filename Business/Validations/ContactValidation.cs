using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Ad"))
                .MaximumLength(100)
                .WithMessage(UIMessages.GetMaxLengthMessage(100,"Ad"));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Email"))
                .EmailAddress()
                .WithMessage(UIMessages.GetEmailErrorMessage());

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Başlıq"))
                .MaximumLength(300)
                .WithMessage(UIMessages.GetMaxLengthMessage(300, "Başlıq"));

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Mesaj"))
                .MaximumLength(2000)
                .WithMessage(UIMessages.GetMaxLengthMessage(2000, "Mesaj"));
        }
    }
}
