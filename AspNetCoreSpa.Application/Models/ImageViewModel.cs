using System;

namespace AspNetCoreSpa.Application.Models
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }
}