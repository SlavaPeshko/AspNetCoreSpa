using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Domain.Entities
{
    public class UserPhoto : BaseEntity<int>
    {
        public string OriginalName { get; set; }
        public string Path { get; set; }

        public string Position { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}