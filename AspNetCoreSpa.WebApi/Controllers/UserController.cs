using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class UserController : BaseController
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
        public async Task<IActionResult> ConfirmEmailAsync(Guid userId)
        {
            var result = await _userService.ConfirmEmailAsync(userId, Url);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmailAsync(Guid userId, string code)
        //{
        //    var result = await _userService.ConfirmEmailAsync(userId);

        //    if (result.IsFailure)
        //        return BadRequest(result.Errors);

        //    return Ok();
        //}
    }
}