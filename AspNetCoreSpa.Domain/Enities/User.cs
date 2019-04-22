﻿using System;
using System.Collections.Generic;
using AspNetCoreSpa.Domain.Enities.Base;
using AspNetCoreSpa.Domain.Enities.Enum;

namespace AspNetCoreSpa.Domain.Enities
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public Country Country { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
