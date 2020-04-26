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
        Task<Result> UpdateUserAsync(int id, UpdateUserInputModel model);
        Task<Result> UpdatePasswordAsync(int id, UpdatePasswordInputModel model);

        // TODO SQRS
        Task<Result<TokenViewModel>> LogInAsync(LogInInputModel model);
        Task<Result<bool>> SendEmailConfirmEmailAsync(int userId);
        Task<Result> ConfirmEmailAsync(string token);
        Task<Result<UserViewModel>> GetUserAsync(int id);

        Task<Result> ChangeEmailAsync(int id, ChangeEmailInputModel model);
    }
}
