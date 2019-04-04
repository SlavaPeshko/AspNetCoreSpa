using FluentValidation;
using AspNetCoreSpa.Domain.Models;
using AspNetCoreSpa.CrossCutting.Resources;

namespace AspNetCoreSpa.Domain.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator()
        {
            RuleFor(c => c.UserCode)
                .NotEmpty()
                .WithMessage(Text.UserCodeRequired);

            RuleFor(c => c.UserCode)
                .MaximumLength(5)
                .WithMessage(Text.UserCodeInvalidLength);
        }
    }
}
