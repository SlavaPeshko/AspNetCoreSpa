namespace AspNetCoreSpa.Domain.Enities
{
    public enum ErrorCode
    {
        // User errors
        UserNotFound = 100,
        PasswordInvalid = 101,
        EmailAlreadyExists = 102,
        EmailAlreadyConfirmed = 103,
        TokenInvalid = 104
    }
}
