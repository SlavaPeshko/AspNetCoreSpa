using AspNetCoreSpa.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreSpa.CrossCutting.Resources;

namespace AspNetCoreSpa.Domain.Validators
{
    public class LoginInputModelValidator : AbstractValidator<LoginInputModel>
    {
        public LoginInputModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(Text.UserCodeRequired);
        }
    }
}
