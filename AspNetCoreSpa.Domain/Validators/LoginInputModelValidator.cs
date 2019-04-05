using AspNetCoreSpa.Domain.Models;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Domain.Validators
{
    public class LoginInputModelValidator : AbstractValidator<LoginInputModel>
    {
        // TODO if email
        public LoginInputModelValidator()
        {
            RuleFor(x => x.EmailOrPhone)
                .NotEmpty()
                .WithMessage(ET.UserCodeRequired);
        }
    }
}
