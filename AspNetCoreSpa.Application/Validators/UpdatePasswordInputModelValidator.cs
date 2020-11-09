using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Validators.Extensions;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public class UpdatePasswordInputModelValidator : AbstractValidator<UpdatePasswordModel>
    {
        public UpdatePasswordInputModelValidator()
        {
            RuleFor(p => p.OldPassword).Password();
            RuleFor(p => p.NewPassword).Password();
            RuleFor(p => p.ConfirmPassword)
                .Equal(x => x.NewPassword)
                .WithMessage(ET.ConfirmationPasswordMatch);
        }
    }
}