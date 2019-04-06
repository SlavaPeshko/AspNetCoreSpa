using AspNetCoreSpa.Domain.Models;
using AspNetCoreSpa.Domain.Validators.Extensions;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Domain.Validators
{
    public class LoginInputModelValidator : AbstractValidator<LoginInputModel>
    {
        private const string at = "@";

        public LoginInputModelValidator()
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
