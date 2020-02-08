using System;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models
{
    public class PostViewModel
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }

    public static class PostViewModelExtensionMethods
    {
        public static PostViewModel ToViewModel(this Domain.Entities.Post post)
        {
            if (post == null) return null;

            return new PostViewModel
            {
                Description = post.Description,
                CreateAt = post.CreateAt,
                UpdateAt = post.UpdateAt
            };
        }

        public static PostViewModel ToViewModel(this PostDto post)
        {
            if (post == null) return null;

            return new PostViewModel
            {
                Description = post.Description,
                CreateAt = post.CreateAt,
                UpdateAt = post.UpdateAt
            };
        }
    }
}
