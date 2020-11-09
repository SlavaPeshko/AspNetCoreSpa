using System;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Validators.Extensions;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public class UserInputModelValidator : AbstractValidator<LogInModel>
    {
        private const char At = '@';

        public UserInputModelValidator()
        {
            When(e => !string.IsNullOrEmpty(e.Email) && e.Email.IndexOf(At, StringComparison.Ordinal) > -1, () =>
            {
                RuleFor(e => e.Email)
                    .NotEmpty()
                    .WithMessage(ET.EmailRequired)
                    .EmailAddress()
                    .WithMessage(ET.EmailInvalid);
            });

            When(e => e.PhoneNumber != null, () =>
            {
                RuleFor(e => e.PhoneNumber)
                    .NotEmpty()
                    .WithMessage(ET.PhoneRequired);

                RuleFor(e => e.CountryCode)
                    .NotEmpty()
                    .WithMessage(ET.PhoneRequired);

                RuleFor(e => new {InternationalPhoneNumber = e.PhoneNumber, e.CountryCode})
                    .Must(x => PhoneNumberValidation.IsValidPhoneNumber(x.InternationalPhoneNumber, x.CountryCode))
                    .WithMessage(ET.PhoneInvalid);
            });

            RuleFor(p => p.Password).Password();
        }
    }
}