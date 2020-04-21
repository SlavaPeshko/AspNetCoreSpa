using System;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;

namespace AspNetCoreSpa.Application.Models
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }
    
    public static class CommentViewModelExtensionMethods
    {
        public static ImageViewModel ToViewModel(this ImageDto image)
        {
            if (image == null) return null;

            return new ImageViewModel
            {
                Id = image.Id,
                Name = image.Name,
                Path = image.Path,
            };
        }
    }
}