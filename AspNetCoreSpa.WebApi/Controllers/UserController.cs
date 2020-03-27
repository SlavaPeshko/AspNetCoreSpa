using System;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

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
        public async Task<IActionResult> Login([FromBody]LogInInputModel model)
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
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserInputModel model)
        {
            var result = await _userService.CreateUserAsync(model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(Login),result.Data);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "User")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(Guid userId)
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
        public async Task<IActionResult> SendEmailConfirmEmailAsync(Guid userId)
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
        public async Task<IActionResult> ConfirmEmailAsync([FromBody]TokenInputModel model)
        {
            var result = await _userService.ConfirmEmailAsync(model.Token);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPost("upload-photo")]
        [Authorize(Roles = "User")]
        [Consumes("multipart/form-data")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadUserPhotoAsync(IFormFile file)
        {
            var result = await _fileService.UploadPhotoAsync(file);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UpdateUserInputModel model)
        {
            var result = await _userService.UpdateUserAsync(id, model);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }
        
        [HttpPut("{id:guid}/password")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdatePasswordAsync(Guid id, UpdatePasswordInputModel model)
        {
            var result = await _userService.UpdatePasswordAsync(id, model);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}