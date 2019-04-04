﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Enities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task PostAsync(User user);
        void Put(User user);
        Task<User> GetUserByIdAsync(Guid id);
        Task<bool> IsUniqueUserCodeAsync(string userCode);
    }
}
