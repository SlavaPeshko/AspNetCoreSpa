using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Entities.Base;

namespace AspNetCoreSpa.Application.Services.Contracts
{
    public interface IUserService : IBaseService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<Result<UserViewModel>> CreateUserAsync(CreateUserInputModel userModel);
        Task<Result> UpdateUserAsync(Guid id, UpdateUserInputModel model);
        Task<Result> UpdatePasswordAsync(Guid id, UpdatePasswordInputModel model);

        // TODO SQRS
        Task<Result<LogInViewModel>> LogInAsync(LogInInputModel model);
        Task<Result<bool>> SendEmailConfirmEmailAsync(Guid userId);
        Task<Result> ConfirmEmailAsync(string token);
        Task<Result<UserViewModel>> GetUserAsync(Guid id);
    }
}
