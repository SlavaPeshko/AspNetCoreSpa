﻿namespace AspNetCoreSpa.Domain.Entities
{
    public enum ErrorCode
    {
        // User errors
        UserNotFound = 100,
        PasswordInvalid = 101,
        EmailAlreadyExists = 102,
        EmailAlreadyConfirmed = 103,
        TokenInvalid = 104,
        PhotoInvalid = 105,
        LengthPhotoInvalid = 106,

        //Post error
        PostNotFound = 200,
    }
}