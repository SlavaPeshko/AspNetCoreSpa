using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Post;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync()
        {
            var result = await _postService.GetPostsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync(Guid id)
        {
            var vm = await _postService.GetPostByIdAsync(id);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreatePostInputModel post, List<IFormFile> image)
        {
            var vm = await _postService.CreatePostAsync(post);

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, Post post)
        {
            var result = await _postService.UpdatePostAsync(id, post);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _postService.DeletePostByIdAsync(id);
            return Ok();
        }
    }
}