using System;

namespace AspNetCoreSpa.Application.Models
{
    public class EmailUpdateToken 
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
