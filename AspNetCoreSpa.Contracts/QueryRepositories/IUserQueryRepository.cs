﻿using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using System;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Contracts.QueryRepositories
{
    public interface IUserQueryRepository
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<bool> IsExistEmailAsync(string email);
    }
}
