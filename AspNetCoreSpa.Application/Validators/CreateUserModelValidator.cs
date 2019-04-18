using FluentValidation;
using AspNetCoreSpa.Application.Models;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class CreateUserModelValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserModelValidator()
        {

        }
    }
}
