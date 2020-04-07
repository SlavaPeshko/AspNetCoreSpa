﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Data.Context;
using AspNetCoreSpa.Data.Repositories.Contracts;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await GetSet()
                .Include(x => x.Country)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await GetSet()
                .Include(c => c.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task PostAsync(User user)
        {
            await GetSet().AddAsync(user);
        }

        public void Put(User user)
        {
            GetSet().Attach(user);
            DbContext.Entry(user).State = EntityState.Modified;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await GetSet()
                .Include(u => u.Roles)
                    .ThenInclude(u => u.Role)
                .Include(u => u.Country)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByPhoneAsync (string phone)
        {
            return await GetSet().SingleOrDefaultAsync(u => u.PhoneNumber == phone);
        }

        public async Task<bool> IsExistEmailAsync(string email)
        {
            return await GetSet().AnyAsync(x => x.Email == email);
        }
    }
}
