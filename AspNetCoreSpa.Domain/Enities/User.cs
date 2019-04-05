using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;

namespace AspNetCoreSpa.Domain.Enities
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            Claims = new HashSet<Claim>();
            Roles = new HashSet<Role>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        
        public string UserCode { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Claim> Claims { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
