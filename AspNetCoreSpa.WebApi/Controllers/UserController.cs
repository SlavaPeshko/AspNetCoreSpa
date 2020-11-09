using System.Net.Mime;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Models.Users;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IFileService _fileService;
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LogInModel model)
        {
            var result = await _userService.LogInAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserModel model)
        {
            var result = await _userService.CreateUserAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(Login), result.Data);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "User")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _userService.GetUserAsync(userId);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpGet("{userId}/email")]
        [Authorize(Roles = "User")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendEmailConfirmEmailAsync(int userId)
        {
            var result = await _userService.SendEmailConfirmEmailAsync(userId);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("confirm-email")]
        [Authorize(Roles = "User")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] TokenModel model)
        {
            var result = await _userService.ConfirmEmailAsync(model.AccessToken);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserModel model)
        {
            var result = await _userService.UpdateUserAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPut("{id:int}/password")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdatePasswordAsync(int id, UpdatePasswordModel model)
        {
            var result = await _userService.UpdatePasswordAsync(id, model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPut("{id:int}/email")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChangeEmailAsync(int id, ChangeEmailModel model)
        {
            var result = await _userService.ChangeEmailAsync(id, model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("sms")]
        [AllowAnonymous]
        public async Task<IActionResult> SendSmsCodeAsync(PhoneNumberModel model)
        {
            var result = await _userService.SendSmsCodeAsync(model.InternationalPhoneNumber, model.CountryCode);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpGet("{email}/forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailAsync(string email)
        {
            var result = await _userService.SendEmailAsync(email);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpGet("{token}/validate")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateTokenAsync(string token)
        {
            var result = await _userService.ValidateTokenAsync(token);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordAsync(PasswordResetModel model)
        {
            var result = await _userService.ForgotPasswordAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("upload-image")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UploadUserImageAsync([FromForm] UserImageInputModel model)
        {
            var result = await _fileService.UploadUserImageAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpGet("photo")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserImageAsync()
        {
            var result = await _fileService.GetUserImageAsync();

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}