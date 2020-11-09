using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class SmsController : ApiController
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendSmsAsync(PhoneNumberModel model)
        {
            var result = await _smsService.SendSmsAsync(model.InternationalPhoneNumber, model.CountryCode);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}