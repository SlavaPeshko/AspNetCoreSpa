using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.Base;
using AspNetCoreSpa.Domain.Entities.Enum;

namespace AspNetCoreSpa.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserAddresses = new HashSet<UserAddress>();
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            UserPhoto = new HashSet<UserPhoto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public string RefreshToken { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public ICollection<UserPhoto> UserPhoto { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}