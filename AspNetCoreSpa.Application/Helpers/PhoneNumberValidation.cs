using System;
using PhoneNumbers;

namespace AspNetCoreSpa.Application.Helpers
{
    public static class PhoneNumberValidation
    {
        public static bool IsValidPhoneNumber(string phone, string countryCode)
        {
            if (string.IsNullOrEmpty(phone))
                throw new ArgumentException(nameof(phone));

            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentException(nameof(countryCode));

            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var phoneNumber = phoneNumberUtil.Parse(phone, countryCode);
                return phoneNumberUtil.IsValidNumber(phoneNumber);
            }
            catch (NumberParseException e)
            {
                return false;
            }
        }
    }
}