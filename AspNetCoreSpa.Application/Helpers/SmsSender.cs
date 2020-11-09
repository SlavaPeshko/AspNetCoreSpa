using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Infrastructure.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AspNetCoreSpa.Application.Helpers
{
    public class SmsSender
    {
        private readonly GlobalSettings _globalSettings;

        public SmsSender(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;

            TwilioClient.Init(_globalSettings.TwilioAccountDetails.AccountSid,
                _globalSettings.TwilioAccountDetails.AuthToken);
        }

        public async Task<MessageResource> SendSmsAsync(string phoneTo, string body = null)
        {
            try
            {
                var message = await MessageResource.CreateAsync(
                    new PhoneNumber(phoneTo),
                    from: new PhoneNumber(_globalSettings.TwilioAccountDetails.PhoneFrom),
                    body: body
                );

                return message;
            }
            catch (Exception e)
            {
                // TODO add log
                return null;
            }
        }
    }
}