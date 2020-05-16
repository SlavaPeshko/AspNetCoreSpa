using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Models
{
    public class UserImageInputModel
    {
        public IFormFile File { get; set; }
        public string Cropped { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
    }
}