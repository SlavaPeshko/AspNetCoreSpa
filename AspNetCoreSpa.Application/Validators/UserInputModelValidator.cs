using System;
using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using AspNetCoreSpa.Application.Validators.Extensions;

namespace AspNetCoreSpa.Application.Validators
{
    public class UserInputModelValidator : AbstractValidator<UserInputModel>
    {
        private const string At = "@";

        public UserInputModelValidator()
        {
            When(e => e.Email.IndexOf(At, StringComparison.Ordinal) > -1, () =>
            {
                RuleFor(e => e.Email)
                    .NotEmpty()
                    .WithMessage(ET.EmailRequired)
                    .EmailAddress()
                    .WithMessage(ET.EmailInvalid);
            });

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage(ET.PhoneRequired);

            RuleFor(p => p.Password).Password();
        }
    }
}
