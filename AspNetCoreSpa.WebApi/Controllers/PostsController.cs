using System;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Comment;
using AspNetCoreSpa.Application.Models.Like;
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
        private readonly ICommentService _commentService;

        public PostsController(IPostService postService,
            ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
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

        [HttpPost("{postId}/comment")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostAsync([FromBody]CreateCommentInputModel comment, int postId)
        {
            var result = await _commentService.CreateComment(comment, postId);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("{postId}/like")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostAsync(int postId, [FromBody] LikeInputModel model)
        {
            var result = await _postService.CreatLikePostAsync(postId, model.IsLike);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok(result.Data);
        }
        
        [HttpDelete("{postId}/like/{likeId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteLikePostAsync(int postId, int likeId)
        {
            var result = await _postService.DeleteLikePostAsync(postId, likeId);
            
            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok(result.Data);
        }
    }
}