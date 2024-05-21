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
                .WithMessage("Ad boş ola bilməz")
                .MaximumLength(100)
                .WithMessage("Ad 100 simvoldan çox ola bilməz");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-poçt ünvanı boş ola bilməz")
                .EmailAddress()
                .WithMessage("Doğru e-poçt ünvanı daxil edin");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlıq boş ola bilməz")
                .MaximumLength(300)
                .WithMessage("Başlıq 300 simvoldan çox ola bilməz");

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Mesaj boş ola bilməz")
                .MaximumLength(2000)
                .WithMessage("Mesaj 2000 simvoldan çox ola bilməz");
        }
    }
}
