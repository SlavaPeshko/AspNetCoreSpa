using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Post;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;
        private readonly ILikeService _likeService;

        public PostsController(IPostService postService,
            ILikeService likeService)
        {
            _postService = postService;
            _likeService = likeService;
        }

        [HttpGet("{page}/{items}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetPostsAsync(int page, int items)
        {
            var result = await _postService.GetPostsAsync(new PostPageFilters
            {
                PageNumber = page,
                ItemsPerPage = items
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var vm = await _postService.GetPostByIdAsync(id);

            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostAsync([FromForm]CreatePostInputModel post)
        {
            var result = await _postService.CreatePostAsync(post);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdatePostInputModel post)
        {
            var result = await _postService.UpdatePostAsync(id, post);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postService.DeletePostByIdAsync(id);
            
            if(result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }
        
        [HttpGet("{id}/like")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetRatingAsync(int id)
        {
            var result = await _likeService.GetRatingByPostIdAsync(id);

            return Ok(result);
        }
    }
}