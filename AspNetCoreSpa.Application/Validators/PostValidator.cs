using AspNetCoreSpa.Domain.Entities;
using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Application.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(c => c.Description)
                .Length(1, 200)
                .Must(c => !string.IsNullOrEmpty(c))
                .WithMessage(ET.LengthDescriptionPostInvalid);
        }
    }
}
