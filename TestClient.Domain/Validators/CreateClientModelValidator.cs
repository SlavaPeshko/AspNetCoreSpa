using FluentValidation;
using TestClient.Domain.Models;
using TestClient.CrossCutting.Resources;

namespace TestClient.Domain.Validators
{
    public sealed class CreateClientModelValidator : AbstractValidator<CreateClientModel>
    {
        public CreateClientModelValidator()
        {
            RuleFor(c => c.ClientCode)
                .NotEmpty()
                .WithMessage(Text.ClientCodeRequired);

            RuleFor(c => c.ClientCode)
                .MaximumLength(5)
                .WithMessage(Text.ClientCodeInvalidLength);
        }
    }
}
