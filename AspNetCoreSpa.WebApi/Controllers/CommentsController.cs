using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models.Comment;
using AspNetCoreSpa.Application.Services.Contracts;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //[HttpGet("{page}/{items}")]
        //[Authorize(Roles = "User")]
        //public async Task<IActionResult> GetCommentsAsync(int page, int items)
        //{
        //    return Ok();
        //}

        //[HttpPost("{postId}")]
        //[Authorize(Roles = "User")]
        //public async Task<IActionResult> PostAsync([FromBody]CreateCommentInputModel comment, Guid postId)
        //{
        //    var result = await _commentService.CreateComment(comment, postId);

        //    if (result.IsFailure)
        //        return BadRequest(result.Errors);

        //    return Ok();
        //}
    }
}