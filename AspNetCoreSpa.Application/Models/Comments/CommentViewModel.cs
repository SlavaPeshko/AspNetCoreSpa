using System;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }

    public static class CommentViewModelExtensionMethods
    {
        public static CommentViewModel ToViewModel(this CommentDto comment)
        {
            if (comment == null) return null;

            return new CommentViewModel
            {
                Id = comment.CommentId,
                Description = comment.CommentDescription,
                CreateAt = comment.CommentCreateAt,
                UpdateAt = comment.CommentUpdateAt
            };
        }
    }
}