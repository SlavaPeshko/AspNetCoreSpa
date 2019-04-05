using FluentValidation;
using AspNetCoreSpa.Domain.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Domain.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator()
        {
            RuleFor(c => c.UserCode)
                .NotEmpty()
                .WithMessage(ET.UserCodeRequired);

            RuleFor(c => c.UserCode)
                .MaximumLength(5)
                .WithMessage(ET.UserCodeInvalidLength);
        }
    }
}
