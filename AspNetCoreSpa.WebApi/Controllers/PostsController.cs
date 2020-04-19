using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Comment;
using AspNetCoreSpa.Application.Models.Post;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetPostByIdAsync(Guid id)
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
        public async Task<IActionResult> PutAsync(Guid id, UpdatePostInputModel post)
        {
            var result = await _postService.UpdatePostAsync(id, post);

            if (result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _postService.DeletePostByIdAsync(id);
            
            if(result.IsFailure)
                return BadRequest(result.Errors);
            
            return Ok();
        }

        [HttpPost("{postId}/comment")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PostAsync([FromBody]CreateCommentInputModel comment, Guid postId)
        {
            var result = await _commentService.CreateComment(comment, postId);

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}