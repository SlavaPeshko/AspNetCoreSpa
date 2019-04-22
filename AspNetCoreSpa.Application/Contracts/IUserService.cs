﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Contracts;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Enities;
using AspNetCoreSpa.Domain.Enities.Base;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserService : IBaseService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<Result<UserViewModel>> CreateUserAsync(CreateUserInputModel userModel);
        void Put(User user);
        
        // TODO SQRS
        Task<Result<LogInViewModel>> LogInAsync(LogInInputModel model);
        Task<bool> IsExistEmailAsync(string email);
        Task<Result<bool>> ConfirmEmailAsync(Guid userId, IUrlHelper url);
    }
}
