using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LogInInputModel model)
        {
            var result = await _userService.LogInAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserInputModel model)
        {
            var result = await _userService.CreateUserAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }


        [HttpPost("{userId}/email")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SendEmailConfirmEmailAsync(Guid userId)
        {
            var result = await _userService.SendEmailConfirmEmailAsync(userId);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("confirm-email")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody]TokenInputModel model)
        {
            var result = await _userService.ConfirmEmailAsync(model.Token);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPost("upload-photo")]
        public async Task<IActionResult> UploadUserPhotoAsync([FromForm]IFormFile file)
        {
            var result = await _userService.UploadUserPhotoAsync(file);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}