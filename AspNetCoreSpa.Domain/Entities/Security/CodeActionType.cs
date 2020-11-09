namespace AspNetCoreSpa.Domain.Entities.Security
{
    public enum CodeActionType
    {
        None = 0,
        ConfirmEmail = 1,
        ConfirmPhone = 2,
        CreateUserByPhone = 3,
        ForgotPasswordByPhone = 4,
        ForgotPasswordByEmail = 5
    }
}