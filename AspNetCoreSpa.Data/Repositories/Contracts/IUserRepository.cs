using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task PostAsync(User user);
        void Put(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByPhoneAsync(string phone);
    }
}
