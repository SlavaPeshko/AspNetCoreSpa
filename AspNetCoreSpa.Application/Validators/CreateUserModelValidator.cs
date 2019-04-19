using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserModelValidator()
        {
            Include(new UserInputModelValidator());

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage(ET.FirstNameRequired);

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage(ET.LastNameRequired);

            RuleFor(c => c.Gender)
                .NotEmpty()
                .WithMessage(ET.GenderRequired);

            RuleFor(c => c.BirthDay)
                .NotEmpty()
                .WithMessage(ET.BirthDayRequired);
        }
    }
}
