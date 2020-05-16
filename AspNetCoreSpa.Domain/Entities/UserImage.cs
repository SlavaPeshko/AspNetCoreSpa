using AspNetCoreSpa.Domain.Entities.Base;
using NetTopologySuite.Geometries;

namespace AspNetCoreSpa.Domain.Entities
{
    public class UserImage : BaseEntity<int>
    {
        public string OriginalName { get; set; }
        public string OriginalImagePath { get; set; }
        public string ProfileImagePath { get; set; }
        public Point Position { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}