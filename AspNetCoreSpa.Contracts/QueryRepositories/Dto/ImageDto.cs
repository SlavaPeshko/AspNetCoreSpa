using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}