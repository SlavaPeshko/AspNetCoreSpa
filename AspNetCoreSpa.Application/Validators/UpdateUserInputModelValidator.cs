using AspNetCoreSpa.Application.Models.Users;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public sealed class UpdateUserInputModelValidator : AbstractValidator<UpdateUserModel>
    {
    }
}