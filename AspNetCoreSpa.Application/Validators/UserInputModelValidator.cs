using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using AspNetCoreSpa.Application.Validators.Extensions;

namespace AspNetCoreSpa.Application.Validators
{
    public class UserInputModelValidator : AbstractValidator<UserInputModel>
    {
        private const string at = "@";

        public UserInputModelValidator()
        {
            When(e => e.EmailOrPhone.IndexOf(at) > -1, () =>
            {
                RuleFor(e => e.EmailOrPhone)
                    .NotEmpty()
                    .WithMessage(ET.EmailRequired)
                    .EmailAddress()
                    .WithMessage(ET.EmailInvalid);
            });

            RuleFor(e => e.EmailOrPhone)
                .NotEmpty()
                .WithMessage(ET.PhoneRequired);

            RuleFor(p => p.Password).Password();
        }
    }
}
