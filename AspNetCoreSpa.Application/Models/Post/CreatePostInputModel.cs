using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Models.Post
{
    public class CreatePostInputModel
    {
        public string Description { get; set; }
    }

    public static class CreatePostInputModelExtensionMethods
    {
        public static Domain.Entities.Post ToEntity(this CreatePostInputModel post)
        {
            if (post == null) return null;
    
            return new Domain.Entities.Post
            {
                Description = post.Description,
            };
        }
    }
}
