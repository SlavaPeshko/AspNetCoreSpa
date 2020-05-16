using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IFileService _fileService;

        public ImagesController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpPost("upload-image")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UploadUserImageAsync([FromForm]UserImageInputModel model)
        {
            var result = await _fileService.UploadUserImageAsync(model);
            
            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}