using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Like;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class LikesController : ApiController
    {
        private readonly ILikeService _likeService;
        
        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostAsync(LikeInputModel model)
        {
            var result = await _likeService.CreateLikePostAsync(model.PostId, model.IsLike);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok(result.Data);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _likeService.DeleteLikeByIdAsync(id);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }
    }
}