using System.Threading.Tasks;
using AspNetCoreSpa.Application.Helpers;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Data.UoW;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Security;
using AspNetCoreSpa.Infrastructure.Options;
using ET = AspNetCoreSpa.CrossCutting.Resources.ErrorTranslation;
using EC = AspNetCoreSpa.Domain.Entities.ErrorCode;

namespace AspNetCoreSpa.Application.Services
{
    public class SmsService : ISmsService
    {
        private readonly GlobalSettings _globalSettings;
        private readonly ISecurityCodesRepository _securityCodesRepository;
        private readonly IUnitOfWorks _unitOfWorks;

        public SmsService(ISecurityCodesRepository securityCodesRepository,
            GlobalSettings globalSettings,
            IUnitOfWorks unitOfWorks)
        {
            _securityCodesRepository = securityCodesRepository;
            _globalSettings = globalSettings;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Result> SendSmsAsync(string phoneNumber, string countryCode)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(countryCode))
                return Result.Fail(EC.PhoneInvalid, ET.PhoneRequired);

            var code = SecurityCode.Create(ProviderType.Phone, phoneNumber, CodeActionType.ConfirmPhone);

            await _securityCodesRepository.CreateAsync(code);
            await _unitOfWorks.CommitAsync();

            var smsSender = new SmsSender(_globalSettings);
            var result = await smsSender.SendSmsAsync(phoneNumber, $"{code.Code} is your verification code.");
            if (result == null)
                return Result.Fail(EC.SmsServiceFailed, ET.SmsServiceFailed);

            return Result.Ok();
        }
    }
}