using FluentValidation;
using AspNetCoreSpa.Application.Models;
namespace AspNetCoreSpa.Application.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserModelValidator()
        {
            Include(new UserInputModelValidator());
        }
    }
}
