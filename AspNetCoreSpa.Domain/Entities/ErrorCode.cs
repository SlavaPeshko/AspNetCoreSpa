namespace AspNetCoreSpa.Domain.Entities
{
    public enum ErrorCode
    {
        // User errors
        UserNotFound = 100,
        PasswordInvalid = 101,
        EmailAlreadyExists = 102,
        EmailAlreadyConfirmed = 103,
        TokenInvalid = 104,
        ImageInvalid = 105,
        LengthImageInvalid = 106,
        AccessFailedCount = 107,
        AddressNotFound = 108,

        //Post error
        PostNotFound = 200,
        LikeNotFound = 201,
    }
}
