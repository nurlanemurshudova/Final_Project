using Business.BaseMessages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class TeacherCandidateValidation : AbstractValidator<TeacherCandidate>
    {
        public TeacherCandidateValidation()
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

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Email"))
                .EmailAddress()
                .WithMessage(UIMessages.GetEmailErrorMessage());

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Telefon nömrəsi"))
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Düzgün telefon nömrəsi daxil edin");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Doğum tarixi"));

            RuleFor(x => x.Experience)
                 .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Təcrübə"));

            RuleFor(x => x.Education)
                 .NotEmpty()
                .WithMessage(UIMessages.GetRequiredMessage("Təhsil"));

        }
    }
}