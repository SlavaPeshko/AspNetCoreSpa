using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserInputModel>
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
