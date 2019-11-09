using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPostsAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostByIdAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync()
        {
            return Ok();
        }
    }
}