using System;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class Claim : BaseEntity<Guid>
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
