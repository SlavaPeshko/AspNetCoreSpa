using System;

namespace AspNetCoreSpa.Application.Models
{
    public class PostViewModel
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
