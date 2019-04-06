using FluentValidation;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;

namespace AspNetCoreSpa.Domain.Validators.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 8)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ET.PasswordRequired)
                .MinimumLength(minimumLength).WithMessage(ET.PasswordInvalidLength)
                .Matches("[A-Z]").WithMessage(ET.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ET.PasswordLowercaseLetter)
                .Matches("[0-9]").WithMessage(ET.PasswordDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(ET.PasswordSpecialCharacter);

            return options;
        }
    }
}
