namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int? UserId { get; set; }

        public int? PostId { get; set; }
    }
}