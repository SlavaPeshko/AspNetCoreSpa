namespace AspNetCoreSpa.Domain.Entities
{
    public enum ErrorCode
    {
        None = 0,

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
        PhoneInvalid = 109,
        PhoneNotFound = 110,
        SmsServiceFailed = 111,
        SecurityCodeInvalid = 112,
        EmailNotFound = 113,
        EmailFailedSend = 114,

        //Post error
        PostNotFound = 200,
        LikeNotFound = 201
    }
}