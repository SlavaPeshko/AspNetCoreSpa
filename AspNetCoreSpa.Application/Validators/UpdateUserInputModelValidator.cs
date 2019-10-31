using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class UpdateUserInputModelValidator : AbstractValidator<UpdateUserInputModel>
    {
        public UpdateUserInputModelValidator()
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

            RuleFor(c => c.DateOfBirth)
                .NotEmpty()
                .WithMessage(ET.BirthDayRequired);

            RuleFor(c => c.ConfirmationPassword)
                .NotEmpty()
                .WithMessage(ET.ConfirmationPasswordRequired);

            RuleFor(c => c.Password)
                .Equal(c => c.ConfirmationPassword)
                .WithMessage(ET.ConfirmationPasswordMatch);
        }
    }
}
