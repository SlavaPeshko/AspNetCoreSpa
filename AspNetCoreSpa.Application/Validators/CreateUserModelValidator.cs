using AspNetCoreSpa.Application.Models.Users;
using FluentValidation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("Something wrong");

            // Include(new UserInputModelValidator());
        }
    }
}