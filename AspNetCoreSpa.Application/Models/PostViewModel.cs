using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreSpa.Application.Models.Comment;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<CommentViewModel> Comments { get; set; }
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
                UpdateAt = post.UpdateAt,
            };
        }

        public static PostViewModel ToViewModel(this PostDto post)
        {
            if (post == null) return null;

            return new PostViewModel
            {
                Id = post.PostId,
                Description = post.PostDescription,
                CreateAt = post.PostCreateAt,
                UpdateAt = post.PostUpdateAt,
                Comments = post.Comments.Select(x => x.ToViewModel()).ToList()
            };
        }
    }
}
