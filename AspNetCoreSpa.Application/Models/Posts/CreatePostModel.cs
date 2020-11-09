using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Models.Posts
{
    public class CreatePostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }
    }

    public static class CreatePostInputModelExtensionMethods
    {
        public static Post ToEntity(this CreatePostModel post)
        {
            if (post == null) return null;

            return new Post
            {
                Title = post.Title,
                Description = post.Description
            };
        }
    }
}